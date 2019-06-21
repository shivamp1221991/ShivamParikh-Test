using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureComputerVisionWithBlob.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using AzureComputerVisionWithBlob;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System.Net.Http;
using System.Threading;

using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Extensions.Options;

namespace AzureComputerVisionWithBlob.Controllers
{
    public class HomeController : Controller
    {
        // Declarations
        CloudStorageAccount storageAccount = null;
        CloudBlobContainer cloudBlobContainer = null;
        dbInterview_2019Context db = new dbInterview_2019Context();
        private AppSettings AppSettings { get; set; }
        // Constructor
        public HomeController(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
            db.AppSettings = settings.Value;
        }
        

        public async Task<ActionResult> Index(List<IFormFile> imageUpload)
        {
            if (imageUpload.Count == 0)
            {
                var img = new ImageTagProcessing();
                img.ImageID = 0;
                img.Tags = null;
                img.ImageURL = "../images/image.png";
                return View(img);
            }
            else {
                string storageConnectionString = AppSettings.BloblConnectionString;

                if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
                {
                    try
                    {
                        // Upload Image to Blob Storage
                        #region <<Upload to blob storage>>
                        CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();
                        cloudBlobContainer = cloudBlobClient.GetContainerReference(AppSettings.BloblContainer);
                        var filePath = imageUpload[0].FileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await imageUpload[0].CopyToAsync(stream);
                        }
                        CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filePath);
                        await cloudBlockBlob.UploadFromFileAsync(filePath);

                        // Remove local file
                        System.IO.File.Delete(filePath);
                        #endregion

                        #region <<Call Cognitive Service andGet Tags>>
                        ComputerVisionClient vision = new ComputerVisionClient(
                        new ApiKeyServiceClientCredentials(AppSettings.CognitiveServiceKey),
                        new System.Net.Http.DelegatingHandler[] { });
                        vision.Endpoint = AppSettings.CongnitiveEndPoint;

                        VisualFeatureTypes[] features = new VisualFeatureTypes[] { VisualFeatureTypes.Tags };
                        var result = await vision.AnalyzeImageAsync(cloudBlockBlob.Uri.ToString(), features);
                        List<string> s = new List<string>();
                        string CommaseperatedValues = "";
                        for (int i = 0; i < result.Tags.Count; i++)
                        {
                            if (CommaseperatedValues != "") {
                                CommaseperatedValues += ",";
                            }
                            CommaseperatedValues += result.Tags[i].Name.ToString();
                            string key = String.Format("Tag{0}", i);
                            s.Add(result.Tags[i].Name.ToString());
                            cloudBlockBlob.Metadata.Add(key, result.Tags[i].Name.ToString());
                        }
                        #endregion

                        # region <<store image details in SQL table>>
                        int imgID = 0;
                        
                        
                        Image dbimg = new Image();
                        
                        dbimg.Name = filePath;
                        dbimg.Path = cloudBlockBlob.Uri.ToString();
                        dbimg.Tags = CommaseperatedValues;
                        dbimg.ExternalKey = "";
                        dbimg.CreateDate = System.DateTime.Now;
                        dbimg.LastModified = null;

                        db.Add(dbimg);
                        db.SaveChanges();
                        imgID = db.Image.OrderByDescending(u => u.ImageId).FirstOrDefault().ImageId;
                        #endregion

                        #region <<Prepare Model to return>>
                        ImageTagProcessing img = new ImageTagProcessing();
                        img.ImageID = imgID;
                        img.Tags = s;
                        img.ImageURL = cloudBlockBlob.Uri.ToString();
                        #endregion
                        return View(img);
                    }
                    catch (Exception ex)
                    {
                        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                    }

                }
            }
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
