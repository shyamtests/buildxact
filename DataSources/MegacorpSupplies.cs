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
        private readonly ICurrencyConverter _currencyConverter;

        public MegacorpSupplies(ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        public IEnumerable<BuildingSupply> GetBuildingSupplies()
        {
            var records = GetMegacorpItemsFromFile();

            return MapMegacorpToBuildingSupply(records);
        }

        private IEnumerable<BuildingSupply> MapMegacorpToBuildingSupply(IEnumerable<MegacorpItem> items)
        {
            return items.Select(s => new BuildingSupply
            {
                Name = s.description, Price =  _currencyConverter.ConvertCentsUsdToDollarsAud(s.priceInCents), Id = s.id.ToString()
            }); // TODO Confirm which ID to use as neither match example data
        }
        
        

        private static IEnumerable<MegacorpItem> GetMegacorpItemsFromFile()
        {
            var assembly = Assembly.GetAssembly(typeof(App));

            using var megacorpFile = assembly.GetManifestResourceStream("buildxact_supplies.megacorp.json");
            using var reader = new StreamReader(megacorpFile);

            var jsonString = reader.ReadToEnd();

            var records = JsonSerializer.Deserialize<Models.MegacorpSuppliers>(jsonString,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            return records.Partners.SelectMany(p => p.Supplies);
        }
    }
}
