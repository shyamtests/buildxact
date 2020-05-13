using System;
using SuppliesPriceLister.Models;
using Xunit;

namespace SuppliesPriceListerTests
{
    public class BuildingSupplyTests
    {
        [Fact]
        public void OutputsValuesInExpectedFormatA()
        {
            var supply = new BuildingSupply
            {
                Id = "7f3c48c4-f8b6-453f-b2fa-83ec31dfa85c", Name = "Bobcat to Dig LM of Strip Footing",
                Price = 800M
            };

            var output = supply.ToString();
            
            Assert.Equal("7f3c48c4-f8b6-453f-b2fa-83ec31dfa85c, Bobcat to Dig LM of Strip Footing, $800.00", output);
        }
        
        [Fact]
        public void OutputsValuesInExpectedFormatB()
        {
            var supply = new BuildingSupply
            {
                Id = "0a360e10-4e35-4e94-bd80-2e8bd6c749f1", Name = "Under Slab Sand 150mm",
                Price = 77.24M
            };

            var output = supply.ToString();
            
            Assert.Equal("0a360e10-4e35-4e94-bd80-2e8bd6c749f1, Under Slab Sand 150mm, $77.24", output);
        }
        
        [Fact]
        public void OutputsValuesInExpectedFormatC()
        {
            var supply = new BuildingSupply
            {
                Id = "4000", Name = "100 x 200 x 20mpa Internal Beam",
                Price = 68.00M
            };

            var output = supply.ToString();
            
            Assert.Equal("4000, 100 x 200 x 20mpa Internal Beam, $68.00", output);
        }
    }
}
