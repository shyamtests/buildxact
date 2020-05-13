using System;

namespace buildxact_supplies.Models
{
    public class HumphriesItem
    {
        public Guid identifier { get; set; }
        public string desc { get; set; }
        public string unit { get; set; }
        public decimal costAUD { get; set; }
    }
}
