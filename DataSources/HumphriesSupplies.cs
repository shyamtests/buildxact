using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using buildxact_supplies.Models;
using CsvHelper;

namespace buildxact_supplies.DataSources
{
    public class HumphriesSupplies: IBuildingSupplies
    {
        public IEnumerable<BuildingSupply> GetBuildingSupplies()
        {
            var assembly = Assembly.GetAssembly(typeof(App));
            using (var humphriesFile = assembly.GetManifestResourceStream("buildxact_supplies.humphries.csv"))
            using (var reader = new StreamReader(humphriesFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<HumphriesItem>().ToList();
                return records.Select(s => new BuildingSupply {Id = s.identifier.ToString(), Name = s.desc, Price = s.costAUD});
            }
        }
    }
}
