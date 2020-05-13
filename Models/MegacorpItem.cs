using System;

namespace buildxact_supplies.Models
{
    public class MegacorpItem
    {
        public int id { get; set; }
        public Guid providerId { get; set; }
        public string description { get; set; }
        public string materialType { get; set; }
        public string uom { get; set; }
        public int priceInCents { get; set; }
    }
}
