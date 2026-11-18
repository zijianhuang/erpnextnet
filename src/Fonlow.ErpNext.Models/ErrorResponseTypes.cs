using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.Models
{
    public class ErrorResponseBase
    {
        [JsonPropertyName("exc_type")]
        public string ExecutionType { get; set; }
    }

    /// <summary>
    /// Typically with 404
    /// </summary>
    public class ErrorResponse : ErrorResponseBase
    {
        [JsonPropertyName("_server_messages")]
        public string[] ServerMessages { get; set; }

        [JsonPropertyName("_error_message")]
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// Typically with 401, 5xx.
    /// </summary>
    public class ExceptionResponse :ErrorResponseBase
    {
        [JsonPropertyName("exc")]
        public string[] Errors { get; set; }

        [JsonPropertyName("exception")]
        public string ExceptionMessage { get; set; }
    }
}
