using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class StaffPhoto
    {
        public int StaffPhotoId { get; set; }
        public int StaffId { get; set; }
        public int PhotoId { get; set; }
        public byte? PermissionLevel { get; set; }

        public Photo Photo { get; set; }
        public Staff Staff { get; set; }
    }
}
