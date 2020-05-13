using System.Collections.Generic;
using System.Linq;
using buildxact_supplies.Models;

namespace buildxact_supplies.DataSources
{
    public class CombinedSupplies : ICombinedSupplies
    {
        private IEnumerable<IBuildingSupplies> _buildingSuppliesDataSources;

        public CombinedSupplies(IEnumerable<IBuildingSupplies> buildingSuppliesDataSources)
        {
            _buildingSuppliesDataSources = buildingSuppliesDataSources;
        }

        public IEnumerable<BuildingSupply> GetAllBuildingSupplies() =>
            _buildingSuppliesDataSources
                .SelectMany(s => s.GetBuildingSupplies())
                .GroupBy(s => s.Id)
                .Select(g => g.First())
                .ToList();
    }
    
    public interface ICombinedSupplies
    {
        public IEnumerable<BuildingSupply> GetAllBuildingSupplies();
    }
}
