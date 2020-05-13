using Microsoft.Extensions.Configuration;

namespace buildxact_supplies
{
    public class CurrencyConverter: ICurrencyConverter
    {
        private readonly IConfiguration _config;

        public CurrencyConverter(IConfiguration config)
        {
            _config = config;
        }
        
        public decimal ConvertCentsUsdToDollarsAud(int centsUsd)
        {
            var exchangeRate = _config.GetValue<decimal>("audUsdExchangeRate");
            var usd = centsUsd / 100M;
            var aud = usd / exchangeRate;
            return aud;
        }
    }
    
    public interface ICurrencyConverter
    {
        public decimal ConvertCentsUsdToDollarsAud(int centsUSD);
    }
}
