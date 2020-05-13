using System.Collections.Generic;

namespace buildxact_supplies.Models
{
    public class MegacorpPartner
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }

        public IEnumerable<MegacorpItem> Supplies { get; set; }
    }


}
