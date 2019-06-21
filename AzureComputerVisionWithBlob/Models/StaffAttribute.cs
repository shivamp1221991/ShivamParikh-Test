using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class StaffAttribute
    {
        public int StaffAttributeId { get; set; }
        public int StaffId { get; set; }
        public string AttributeKey { get; set; }
        public int? AttributeValue { get; set; }
        public string AttributeSet { get; set; }

        public Staff Staff { get; set; }
    }
}
