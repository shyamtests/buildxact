using System.Collections.Generic;
using System.Linq;
using buildxact_supplies;
using buildxact_supplies.DataSources;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace SuppliesPriceListerTests
{
    public class CombinedSuppliesTests
    {
        [Fact]
        public void CombinesDistinctEntiesOnly()
        {
            var suppliesA = new HumphriesSupplies();
            var suppliesB = new HumphriesSupplies();
            
            var myConfiguration = new Dictionary<string, string>
            {
                {"audUsdExchangeRate", "0.5"}
            };

            
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            
            
            var suppliesC = new MegacorpSupplies(new CurrencyConverter(configuration));

            var combinedSupplies = new CombinedSupplies( new IBuildingSupplies[] {suppliesA, suppliesB, suppliesC});

            var result = combinedSupplies.GetAllBuildingSupplies();
            
            Assert.Equal(suppliesA.GetBuildingSupplies().Concat(suppliesC.GetBuildingSupplies()).ToList().Count, result.ToList().Count);






        }
    }
}
