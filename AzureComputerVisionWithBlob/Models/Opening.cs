using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class Opening
    {
        public Opening()
        {
            Waitlist = new HashSet<Waitlist>();
        }

        public int OpeningId { get; set; }
        public int? ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StaffId { get; set; }
        public int? SpareId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? FillDate { get; set; }
        public string Note { get; set; }

        public Schedule Schedule { get; set; }
        public Spare Spare { get; set; }
        public Staff Staff { get; set; }
        public ICollection<Waitlist> Waitlist { get; set; }
    }
}
