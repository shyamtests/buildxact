using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using buildxact_supplies;
using buildxact_supplies.Models;
using Xunit;

namespace SuppliesPriceListerTests
{
    
    [UseReporter(typeof(DiffReporter))]
    public class DisplayTests
    {
        [Fact]
        public void TestWritingToConsole()
        {
            var supplyA = new BuildingSupply
            {
                Id = "4000", Name = "100 x 200 x 20mpa Internal Beam",
                Price = 68.00M
            };
            
            var supplyB = new BuildingSupply
            {
                Id = "7f3c48c4-f8b6-453f-b2fa-83ec31dfa85c", Name = "Bobcat to Dig LM of Strip Footing",
                Price = 800M
            };
            
            var supplyC = new BuildingSupply
            {
                Id = "0a360e10-4e35-4e94-bd80-2e8bd6c749f1", Name = "Under Slab Sand 150mm",
                Price = 77.24M
            };

            var supplies = new[] {supplyA, supplyB, supplyC};
            
            using (var consoleOutput = new ConsoleOutput())
            {
                ConsoleWriter.WriteSuppliesToConsole(supplies);

                Approvals.Verify(consoleOutput.GetOuput());
            }
        }
    }
}
