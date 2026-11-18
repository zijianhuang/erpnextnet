using Fonlow.ErpNext;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Fonlow.ErpNextAsp
{
    /// <summary>
    /// A custom model binder that deserializes JSON data from the request body into a specified type T, using custom converters specific to ErpNext, 
    /// for example, the ErpNextDateTimeConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ErpJsonModelBinder<T> : IModelBinder  //crafted by M365 copilot
    {
        private readonly JsonSerializerOptions _options;

        public ErpJsonModelBinder(IConfiguration config)
        {
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var timeZoneId = config["ERPNext:TimeZoneId"];
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            _options.Converters.Add(new ErpNextDateTimeConverter(timeZoneInfo));
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            using var reader = new StreamReader(bindingContext.HttpContext.Request.Body);
            var body = await reader.ReadToEndAsync();
            var model = JsonSerializer.Deserialize<T>(body, _options);
            bindingContext.Result = ModelBindingResult.Success(model);
        }
    }

}
