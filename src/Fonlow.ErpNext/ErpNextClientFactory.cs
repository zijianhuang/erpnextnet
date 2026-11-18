using Microsoft.Extensions.Configuration;

namespace Fonlow.ErpNext

{
    public static class ErpNextClientFactory
    {
        public static ErpNextClient Create(IConfiguration config)
        {
            var erpNextSettings = config.GetSection("ERPNext");
            var baseUri = new System.Uri(erpNextSettings["baseUrl"]);
            var apiKey = erpNextSettings["ApiKey"];
            var apiSecret = erpNextSettings["ApiSecret"];
            var timeZoneId = erpNextSettings["TimeZoneId"];
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return new ErpNextClient(baseUri, apiKey, apiSecret, timeZoneInfo);
        }
    }
}
