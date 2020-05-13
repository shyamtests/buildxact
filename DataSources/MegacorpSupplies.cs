using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using buildxact_supplies.Models;

namespace buildxact_supplies.DataSources
{
    public class MegacorpSupplies : IBuildingSupplies
    {
        public IEnumerable<BuildingSupply> GetBuildingSupplies()
        {
            var assembly = Assembly.GetAssembly(typeof(App));
            
            string[] names = assembly.GetManifestResourceNames();
            using var megacorpFile = assembly.GetManifestResourceStream("buildxact_supplies.megacorp.json");
            using var reader = new StreamReader(megacorpFile);
            
            var jsonString = reader.ReadToEnd();
            var jsonDocument = JsonDocument.Parse(jsonString);

            var partners = jsonDocument.RootElement.GetProperty("partners");
                
            var supplies = partners.EnumerateArray().First().GetProperty("supplies"); // FIXME get megacorp not just the first

            var records = JsonSerializer.Deserialize<IEnumerable<MegacorpItem>>(supplies.GetRawText(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                
            return records.Select(s => new BuildingSupply
            {
                Name = s.description, Price = s.priceInCents / 100M, Id = s.id.ToString()
            }); // TODO Confirm which ID to use as neither match example data
            // TODO Add Currency COnversion
        }
    }
}
