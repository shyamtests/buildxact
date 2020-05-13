using System;
using System.Linq;
using buildxact_supplies.DataSources;
using Microsoft.Extensions.Configuration;

namespace buildxact_supplies
{
    public class App
    {
        private readonly IConfiguration _config;
        private readonly ICombinedSupplies _combinedSupplies;

        public App(IConfiguration config, ICombinedSupplies combinedSupplies)
        {
            _config = config;
            _combinedSupplies = combinedSupplies;
        }

        public void Run()
        {
            var supplies = _combinedSupplies.GetAllBuildingSupplies();

            var sorted = supplies.OrderBy(s => s.Price);
            var output = sorted.Select(s => s.ToString());

            output.ToList().ForEach(Console.WriteLine);
        }
    }
}
