using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class Waitlist
    {
        public int WaitlistId { get; set; }
        public int OpeningId { get; set; }
        public int SpareId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Comment { get; set; }

        public Opening Opening { get; set; }
        public Spare Spare { get; set; }
    }
}
