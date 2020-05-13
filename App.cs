using System;
using Microsoft.Extensions.Configuration;

namespace buildxact_supplies
{
    public class App
    {
        private readonly IConfiguration _config;

        public App(IConfiguration config)
        {
            _config = config;
        }
        
        public void Run()
        {
            Console.WriteLine($"Hello from App.cs exchange rate is {_config.GetValue<decimal>("audUsdExchangeRate")}");
        }
    }
}
