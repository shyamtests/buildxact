using System.Collections.Generic;
using buildxact_supplies;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace SuppliesPriceListerTests
{
    public class CurrencyConverterTests
    {
        [Fact]
        public void ConvertsFromCentsUSDToAUDA()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"audUsdExchangeRate", "0.1"}
            };



            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var converter = new CurrencyConverter(configuration);

            var result = converter.ConvertCentsUsdToDollarsAud(10000);
            Assert.Equal(1000, result);

        }
        
        [Fact]
        public void ConvertsFromCentsUSDToAUDB()
        {
            var myConfiguration = new Dictionary<string, string>
            {
                {"audUsdExchangeRate", "0.646134"}
            };



            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();

            var converter = new CurrencyConverter(configuration);

            var result = converter.ConvertCentsUsdToDollarsAud(100);
            Assert.Equal(1.5476665830926711796624229649M, result);

        }
    }
}
