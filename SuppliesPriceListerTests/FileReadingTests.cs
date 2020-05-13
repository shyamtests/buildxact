using ApprovalTests;
using ApprovalTests.Reporters;
using buildxact_supplies.DataSources;
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
            var supplies = new MegacorpSupplies().GetBuildingSupplies();
            
            Approvals.VerifyJson(JsonConvert.SerializeObject(supplies));
        }
    }
}
