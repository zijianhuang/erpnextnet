using Fonlow.ErpNext.Models;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("Campaign")]
    public class CampaignDT: DocTypeBase
    {
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

        [JsonPropertyName("campaign_name")]
        public string CampaignName { get; set; }

        [JsonPropertyName("naming_series")]
        public string NamingSeries { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
