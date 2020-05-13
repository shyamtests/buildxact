using System.Collections.Generic;
using buildxact_supplies.Models;

namespace buildxact_supplies.DataSources
{
    public interface IBuildingSupplies
    {
        public IEnumerable<BuildingSupply> GetBuildingSupplies();
    }
}
