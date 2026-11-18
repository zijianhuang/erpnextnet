using Fonlow.ErpNext.Models;
using Fonlow.ErpNext.Models.ChildDocTypes;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("Contact")]
    public class ContactDT : DocTypeWithLinks
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

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("sync_with_google_contacts")]
        public int SyncWithGoogleContacts { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("salutation")]
        public string Salutation { get; set; }

        [JsonPropertyName("designation")]
        public string Designation { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("mobile_no")]
        public string MobileNo { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("google_contacts")]
        public string GoogleContacts { get; set; }

        [JsonPropertyName("google_contacts_id")]
        public string GoogleContactsId { get; set; }

        [JsonPropertyName("pulled_from_google_contacts")]
        public int PulledFromGoogleContacts { get; set; }

        [JsonPropertyName("is_primary_contact")]
        public int IsPrimaryContact { get; set; }

        [JsonPropertyName("is_billing_contact")]
        public int IsBillingContact { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("unsubscribed")]
        public int Unsubscribed { get; set; }

        [JsonPropertyName("phone_nos")]
        public List<ContactPhoneNumber> PhoneLinks { get; set; }

        [JsonPropertyName("email_ids")]
        public List<EmailLink> EmailLinks { get; set; }
    }

}
