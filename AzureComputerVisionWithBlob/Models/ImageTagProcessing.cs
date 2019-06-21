using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureComputerVisionWithBlob.Models
{
    public class ImageTagProcessing
    {
        public string ImageURL { get; set; }
        public List<string> Tags { get; set; }
        public int ImageID { get; set; }
    }
}
