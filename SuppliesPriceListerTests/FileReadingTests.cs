using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using buildxact_supplies;
using buildxact_supplies.DataSources;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;

namespace SuppliesPriceListerTests
{
    [UseReporter(typeof(DiffReporter))]
    public class FileReadingTests
    {
        [Fact]
        public void HumphriesReadsEmbeddedFilesAndConvertsToBuildingSupplies()
        {
            var supplies = new HumphriesSupplies().GetBuildingSupplies();
            
            Approvals.VerifyJson(JsonConvert.SerializeObject(supplies));
        }
        
        [Fact]
        public void MegaCorpReadsEmbeddedFilesAndConvertsToBuildingSupplies()
        {

            var myConfiguration = new Dictionary<string, string>
            {
                {"audUsdExchangeRate", "1"}
            };

            
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            
            
            var supplies = new MegacorpSupplies(new CurrencyConverter(configuration)).GetBuildingSupplies();
            
            Approvals.VerifyJson(JsonConvert.SerializeObject(supplies));
        }
        
        // Prices for this approval test should be double the previous
        [Fact]
        public void MegaCorpReadsEmbeddedFilesAndConvertsToBuildingSuppliesAndConvertsToAud()
        {

            var myConfiguration = new Dictionary<string, string>
            {
                {"audUsdExchangeRate", "0.5"}
            };

            
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
            
            
            var supplies = new MegacorpSupplies(new CurrencyConverter(configuration)).GetBuildingSupplies();
            
            Approvals.VerifyJson(JsonConvert.SerializeObject(supplies));
        }
    }
}
