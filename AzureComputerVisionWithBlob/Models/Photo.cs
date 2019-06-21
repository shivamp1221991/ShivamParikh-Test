using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class Photo
    {
        public Photo()
        {
            SparePhoto = new HashSet<SparePhoto>();
            StaffPhoto = new HashSet<StaffPhoto>();
        }

        public int PhotoId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }

        public ICollection<SparePhoto> SparePhoto { get; set; }
        public ICollection<StaffPhoto> StaffPhoto { get; set; }
    }
}
