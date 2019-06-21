using System;
using System.Collections.Generic;

namespace AzureComputerVisionWithBlob.Models
{
    public partial class SpareAttribute
    {
        public int SpareAttributeId { get; set; }
        public int SpareId { get; set; }
        public string AttributeKey { get; set; }
        public int? AttributeValue { get; set; }
        public string AttributeSet { get; set; }

        public Spare Spare { get; set; }
    }
}
