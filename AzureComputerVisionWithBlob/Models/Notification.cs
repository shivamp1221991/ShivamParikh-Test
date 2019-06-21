using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int StaffId { get; set; }
        public int AdminStaffId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime? AcknowledgementDate { get; set; }
        public string Ip { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public Staff AdminStaff { get; set; }
        public Staff Staff { get; set; }
    }
}
