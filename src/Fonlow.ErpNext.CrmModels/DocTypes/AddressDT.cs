using Fonlow.ErpNext.Models;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    /// <summary>
    /// ERPNext models relationships like addresses and contacts through reverse links — meaning the  and  DocTypes link to the Customer, not the other way around.
    /// </summary>
    [ErpNextDocType("Address")]
    public class AddressDT : DocTypeWithLinks
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

        [JsonPropertyName("address_title")]
        public string AddressTitle { get; set; }

        [JsonPropertyName("address_type")]
        public string AddressType { get; set; }

        [JsonPropertyName("address_line1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("address_line2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("pincode")]
        public string Pincode { get; set; }

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("tax_category")]
        public string TaxCategory { get; set; }

        [JsonPropertyName("is_primary_address")]
        public int IsPrimaryAddress { get; set; }

        [JsonPropertyName("is_shipping_address")]
        public int IsShippingAddress { get; set; }

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }

        [JsonPropertyName("is_your_company_address")]
        public int IsYourCompanyAddress { get; set; }

    }
}
