using System;
using System.Collections.Generic;
using System.Linq;
using buildxact_supplies.Models;

namespace buildxact_supplies
{
    public static class ConsoleWriter
    {
        public static void WriteSuppliesToConsole(IEnumerable<BuildingSupply> supplies)
        {
            var sorted = supplies.OrderBy(s => s.Price);
            var output = sorted.Select(s => s.ToString());

            output.ToList().ForEach(s =>
            {
                Console.WriteLine(s);
                Console.WriteLine();
            });
        }
    }
}
