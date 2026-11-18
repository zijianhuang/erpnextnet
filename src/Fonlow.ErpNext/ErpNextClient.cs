using Fonlow.ErpNext.Abstract;
using Fonlow.ErpNext.DocTypes;
using Fonlow.Net.Http.ErpNext;
using System.Text.Json;

namespace Fonlow.ErpNext
{
    /// <summary>
    /// Common REST calls with ERPNext API key+secret.
    /// In ERPNext, name in API is ID in UI
    /// https://docs.frappe.io/framework/user/en/api/rest
    /// </summary>
    public class ErpNextClient
    {
        readonly HttpClient httpClient;
        readonly JsonSerializerOptions jsonSerializerOptions;
        readonly TimeZoneInfo timeZoneInfo;

        /// <summary>
        /// API call will have Authorization header with token {apiKey}:{apiSecret}.
        /// </summary>
        /// <param name="baseUri">The base URI of the ERPNext API like https://myerp.mycompany.net/</param>
        /// <param name="apiKey">ErpNext API key</param>
        /// <param name="apiSecret">ErpNext API secret</param>
        /// <param name="docTypeDic">map DocType with the liternal string</param>
        /// <param name="timeZoneInfo">Used for datetime conversion</param>
        public ErpNextClient(Uri baseUri, string apiKey, string apiSecret, TimeZoneInfo timeZoneInfo)
        {
#if DEBUG
            httpClient = new HttpClient(AcceptAnyCertificateHandler);
#else
            httpClient = new HttpClient();
#endif
            httpClient.BaseAddress = baseUri;
            this.timeZoneInfo = timeZoneInfo;
            this.jsonSerializerOptions = NewSerializerOptions();

            httpClient.DefaultRequestHeaders.Add("Authorization", $"token {apiKey}:{apiSecret}");
        }

        JsonSerializerOptions NewSerializerOptions()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ErpNextDateTimeConverter(timeZoneInfo));// like "2026-02-23 08:58:19.681199"
            options.Converters.Add(new Fonlow.Text.Json.DateOnlyExtensions.DateOnlyJsonConverter());
            return options;
        }

        JsonSerializerOptions NewSerializerOptionsForObjectOrArray<T>()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ErpNextDateTimeConverter(timeZoneInfo));
            options.Converters.Add(new Fonlow.Text.Json.DateOnlyExtensions.DateOnlyJsonConverter());
            options.Converters.Add(new DocTypeArrayResponseConverter<T>());
            return options;
        }

        private static HttpClientHandler AcceptAnyCertificateHandler => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };

        /// <summary>
        /// Generic call of GET resource, without type constraints. Generally you should use those with type constraints.
        /// This function is generally used for researching the data types of ErpNext, since T is not constrainted. In short, you may use this for experiments in test cases.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="docType">Of DocTypeBase</param>
        /// <param name="name"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<T> GetAnyResourceAsync<T>(string docType, string name = null, string query = null)
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/resource/{docType}/{(string.IsNullOrEmpty(name) ? string.Empty : Uri.EscapeDataString(name))}" + (query != null ? $"?{query}" : string.Empty));
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return default(T); }
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<T>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }

        ///// <summary>
        ///// Get single data object of response
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="DataT">Of DocTypeBase</typeparam>
        ///// <param name="docType">Of DocTypeBase</param>
        ///// <param name="name">Required</param>
        ///// <param name="query"></param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException"></exception>
        //[Obsolete]
        //public async Task<DocTypeResponse<DataT>> GetResourceDocTypeResponseAsync<DataT>(string docType, string name, string query = null)
        //    where DataT : DocTypeBase
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        throw new ArgumentNullException(nameof(name));
        //    }

        //    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/resource/{docType}/{Uri.EscapeDataString(name)}/" + (query != null ? $"?{query}" : string.Empty));
        //    var responseMessage = await httpClient.SendAsync(httpRequestMessage);
        //    try
        //    {
        //        responseMessage.EnsureSuccessStatusCodeEx();
        //        if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return default(DocTypeResponse<DataT>); }
        //        var stream = await responseMessage.Content.ReadAsStreamAsync();
        //        return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
        //    }
        //    finally
        //    {
        //        responseMessage.Dispose();
        //    }
        //}

        public async Task<DocTypeResponse<DataT>> GetResourceDocTypeResponseAsync<DataT>(string name, string query = null)
            where DataT : DocTypeBase
        {
            Type dataType = typeof(DataT);
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/resource/{DocTypeName.Get<DataT>()}/{Uri.EscapeDataString(name)}/" + (query != null ? $"?{query}" : string.Empty));
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return default(DocTypeResponse<DataT>); }
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Get array data object of response
        /// </summary>
        /// <typeparam name="DataT">Of DocTypeBase</typeparam>
        /// <param name="name"></param>
        /// <param name="escapedQuery"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<DocTypeArrayResponse<DataT>> GetResourceDocTypArrayResponseAsync<DataT>(string name = null, string escapedQuery = null)
             where DataT : DocTypeBase
        {
            Type dataType = typeof(DataT);
            var requestUri = $"api/resource/{DocTypeName.Get<DataT>()}/{(string.IsNullOrEmpty(name) ? string.Empty : Uri.EscapeDataString(name))}" + (escapedQuery != null ? $"?{escapedQuery}" : string.Empty);
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return default(DocTypeArrayResponse<DataT>); }
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                var options = NewSerializerOptionsForObjectOrArray<DocTypeArrayResponse<DataT>>();
                return JsonSerializer.Deserialize<DocTypeArrayResponse<DataT>>(stream, options);
            }
            finally
            {
                responseMessage.Dispose();
            }

            throw new NotImplementedException();
        }

        //[Obsolete]
        //public async Task<DocTypeArrayResponse<DataT>> GetResourceDocTypArrayResponseAsync<DataT>(string docType, string name = null, string escapedQuery = null)
        //     where DataT : DocTypeBase
        //{
        //    var requestUri = $"api/resource/{docType}/{(string.IsNullOrEmpty(name) ? string.Empty : Uri.EscapeDataString(name))}" + (escapedQuery != null ? $"?{escapedQuery}" : string.Empty);
        //    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
        //    var responseMessage = await httpClient.SendAsync(httpRequestMessage);
        //    try
        //    {
        //        responseMessage.EnsureSuccessStatusCodeEx();
        //        if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return default(DocTypeArrayResponse<DataT>); }
        //        var stream = await responseMessage.Content.ReadAsStreamAsync();
        //        var options = NewSerializerOptionsForObjectOrArray<DocTypeArrayResponse<DataT>>();
        //        return JsonSerializer.Deserialize<DocTypeArrayResponse<DataT>>(stream, options);
        //    }
        //    finally
        //    {
        //        responseMessage.Dispose();
        //    }
        //}

        //public async Task<DocTypeResponse<DataT>> CreateResourceAsync<DataT>(string docType, DataT data) 
        //    where DataT: DocTypeBase
        //{
        //    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/resource/{docType}");
        //    var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
        //    httpRequestMessage.Content = content;
        //    var responseMessage = await httpClient.SendAsync(httpRequestMessage);
        //    try
        //    {
        //        responseMessage.EnsureSuccessStatusCodeEx();
        //        var stream = await responseMessage.Content.ReadAsStreamAsync();
        //        return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
        //    }
        //    finally
        //    {
        //        responseMessage.Dispose();
        //    }
        //}

        /// <summary>
        /// Add Doctype resource.
        /// </summary>
        /// <typeparam name="DataT">Of DocTypeBase</typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<DocTypeResponse<DataT>> CreateResourceAsync<DataT>(DataT data)
            where DataT : DocTypeBase
        {
            Type dataType = typeof(DataT);
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/resource/{DocTypeName.Get<DataT>()}");
            var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
            httpRequestMessage.Content = content;
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="DataT"></typeparam>
        /// <param name="name">The name of the DocType that has been created in draft.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<DocTypeResponse<DataT>> SubmitResourceAsync<DataT>(string name)
            where DataT : DocTypeBase
        {
            Type dataType = typeof(DataT);
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/resource/{DocTypeName.Get<DataT>()}/{Uri.EscapeDataString(name)}?run_method=submit");
            // var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
            // httpRequestMessage.Content = content;
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Update DocType resource
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<DocTypeResponse<DataT>> UpdateResourceAsync<DataT>(string name, DataT data)
            where DataT : DocTypeBase
        {
            Type dataType = typeof(DataT);
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"api/resource/{DocTypeName.Get<DataT>()}/{Uri.EscapeDataString(name)}");
            var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
            httpRequestMessage.Content = content;
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }

            throw new NotImplementedException();
        }

        //[Obsolete]
        //public async Task<DocTypeResponse<DataT>> UpdateResourceAsync<DataT>(string docType, string name, DataT data) 
        //    where DataT : DocTypeBase
        //{
        //    using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"api/resource/{docType}/{Uri.EscapeDataString(name)}");
        //    var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
        //    httpRequestMessage.Content = content;
        //    var responseMessage = await httpClient.SendAsync(httpRequestMessage);
        //    try
        //    {
        //        responseMessage.EnsureSuccessStatusCodeEx();
        //        var stream = await responseMessage.Content.ReadAsStreamAsync();
        //        return JsonSerializer.Deserialize<DocTypeResponse<DataT>>(stream, jsonSerializerOptions);
        //    }
        //    finally
        //    {
        //        responseMessage.Dispose();
        //    }
        //}

        /// <summary>
        /// Delete DocType resource by ID name.
        /// </summary>
        /// <param name="docType">Of DocTypeBase</param>
        /// <param name="name">ID</param>
        /// <returns></returns>
        public async Task<DataStringResponse> DeleteResourceAsync(string docType, string name)
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"api/resource/{docType}/{Uri.EscapeDataString(name)}");
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<DataStringResponse>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }

        /// <summary>
        /// Call frappe method for any data
        /// </summary>
        /// <typeparam name="DataT"></typeparam>
        /// <param name="methodName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<MessageResponse> MethodPostAsync<DataT>(string methodName, DataT data)
        {
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"api/method/{methodName}");
            var content = System.Net.Http.Json.JsonContent.Create(data, mediaType: null, jsonSerializerOptions);
            httpRequestMessage.Content = content;
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<MessageResponse>(stream, jsonSerializerOptions);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }

        /// <summary>
        /// Get DocType count.
        /// for example: https://erpstaging.termatrac.net/api/method/frappe.client.get_count?doctype=Customer
        /// </summary>
        /// <param name="docType">Of DocTypeBase</param>
        /// <param name="active">Active records only</param>
        /// <returns></returns>
        public async Task<int> GetDocTypeCount(string docType, bool active = true)
        {
            var query = active ? $"api/method/frappe.client.get_count?doctype={docType}&filters=[[\"disabled\",\"=\",0]]" : $"api/method/frappe.client.get_count?doctype={docType}";
            using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"api/method/frappe.client.get_count?doctype={docType}");
            var responseMessage = await httpClient.SendAsync(httpRequestMessage);
            try
            {
                responseMessage.EnsureSuccessStatusCodeEx();
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent) { return 0; }
                var stream = await responseMessage.Content.ReadAsStreamAsync();
                var response = JsonSerializer.Deserialize<NumberMessageResponse>(stream);
                return response.Message;
            }
            finally
            {
                responseMessage.Dispose();
            }
        }


    }
}


namespace Fonlow.Net.Http.ErpNext // replicated from WebApiClientGen generated codes.
{
    using System.Net.Http;

    public class WebApiRequestException : HttpRequestException
    {
        public new System.Net.HttpStatusCode StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Net.Http.Headers.HttpResponseHeaders Headers { get; private set; }

        public System.Net.Http.Headers.MediaTypeHeaderValue ContentType { get; private set; }

        public WebApiRequestException(string message, System.Net.HttpStatusCode statusCode, string response, System.Net.Http.Headers.HttpResponseHeaders headers, System.Net.Http.Headers.MediaTypeHeaderValue contentType) : base(message)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
            ContentType = contentType;
        }
    }

    public static class ResponseMessageExtensions
    {
        public static void EnsureSuccessStatusCodeEx(this HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseText = responseMessage.Content.ReadAsStringAsync().Result;
                var contentType = responseMessage.Content.Headers.ContentType;
                throw new WebApiRequestException(responseMessage.ReasonPhrase, responseMessage.StatusCode, responseText, responseMessage.Headers, contentType);
            }
        }
    }
}
