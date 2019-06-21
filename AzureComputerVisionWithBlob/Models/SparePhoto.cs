using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class SparePhoto
    {
        public int SparePhotoId { get; set; }
        public int SpareId { get; set; }
        public int PhotoId { get; set; }
        public byte? PermissionLevel { get; set; }

        public Photo Photo { get; set; }
        public Spare Spare { get; set; }
    }
}
