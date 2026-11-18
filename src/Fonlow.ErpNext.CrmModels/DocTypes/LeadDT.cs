using Fonlow.ErpNext.Models;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("Lead")]
    public class LeadDT: DocTypeBase
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

        [JsonPropertyName("naming_series")]
        public string NamingSeries { get; set; }

        [JsonPropertyName("salutation")]
        public string Salutation { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("lead_name")]
        public string LeadName { get; set; }

        [JsonPropertyName("job_title")]
        public string JobTitle { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("lead_owner")]
        public string LeadOwner { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("customer")]
        public string Customer { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("request_type")]
        public string RequestType { get; set; }

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("mobile_no")]
        public string MobileNo { get; set; }

        [JsonPropertyName("whatsapp_no")]
        public string WhatsappNo { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("phone_ext")]
        public string PhoneExt { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("no_of_employees")]
        public string NoOfEmployees { get; set; }

        [JsonPropertyName("annual_revenue")]
        public decimal AnnualRevenue { get; set; }

        [JsonPropertyName("industry")]
        public string Industry { get; set; }

        [JsonPropertyName("market_segment")]
        public string MarketSegment { get; set; }

        [JsonPropertyName("territory")]
        public string Territory { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("qualification_status")]
        public string QualificationStatus { get; set; }

        [JsonPropertyName("qualified_by")]
        public string QualifiedBy { get; set; }

        [JsonPropertyName("qualified_on")]
        public DateOnly? QualifiedOn { get; set; }

        [JsonPropertyName("campaign_name")]
        public string CampaignName { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }

        [JsonPropertyName("unsubscribed")]
        public int Unsubscribed { get; set; }

        [JsonPropertyName("blog_subscriber")]
        public int BlogSubscriber { get; set; }
    }

}
