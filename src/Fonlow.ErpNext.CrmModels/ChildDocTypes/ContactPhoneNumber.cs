using System.Text.Json.Serialization;
using Fonlow.ErpNext.DocTypes;

namespace Fonlow.ErpNext.Models.ChildDocTypes
{
    public class ContactPhoneNumber : PhoneLink
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("creation")]
        public DateTime Creation { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("docstatus")]
        public int DocStatus { get; set; }

        [JsonPropertyName("idx")]
        public int Idx { get; set; }

        [JsonPropertyName("parent")]
        public string Parent { get; set; }

        [JsonPropertyName("parentfield")]
        public string ParentField { get; set; }

        [JsonPropertyName("parenttype")]
        public string ParentType { get; set; }
    }

}
