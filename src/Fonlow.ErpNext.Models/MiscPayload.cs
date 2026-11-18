using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.Models
{
    public class AddTagsRequest
    {
        [JsonPropertyName("dt")]
        public string DT { get; set; }
        [JsonPropertyName("dn")]
        public string DN { get; set; }
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }


    public class SubmitPayload
    {
        [JsonPropertyName("doc")]
        public SubmitDoc Doc { get; set; }
    }

    public class SubmitDoc
    {
        [JsonPropertyName("doctype")]
        public string DocType { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
