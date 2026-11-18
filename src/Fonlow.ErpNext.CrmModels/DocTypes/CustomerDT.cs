using Fonlow.ErpNext.Models;
using System.Text.Json.Serialization;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("Customer")]
    public class CustomerDT: DocTypeBase
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

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }

        [JsonPropertyName("customer_type")]
        public string CustomerType { get; set; }

        [JsonPropertyName("customer_group")]
        public string CustomerGroup { get; set; }

        [JsonPropertyName("territory")]
        public string Territory { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("lead_name")]
        public string LeadName { get; set; }

        [JsonPropertyName("opportunity_name")]
        public string OpportunityName { get; set; }

        [JsonPropertyName("prospect_name")]
        public string ProspectName { get; set; }

        [JsonPropertyName("account_manager")]
        public string AccountManager { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonPropertyName("default_bank_account")]
        public string DefaultBankAccount { get; set; }

        [JsonPropertyName("default_price_list")]
        public string DefaultPriceList { get; set; }

        [JsonPropertyName("is_internal_customer")]
        public int IsInternalCustomer { get; set; }

        [JsonPropertyName("represents_company")]
        public string RepresentsCompany { get; set; }

        [JsonPropertyName("market_segment")]
        public string MarketSegment { get; set; }

        [JsonPropertyName("industry")]
        public string Industry { get; set; }

        [JsonPropertyName("customer_pos_id")]
        public string CustomerPosId { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("customer_details")]
        public string CustomerDetails { get; set; }

        [JsonPropertyName("customer_primary_address")]
        public string CustomerPrimaryAddress { get; set; }

        [JsonPropertyName("primary_address")]
        public string PrimaryAddress { get; set; }

        [JsonPropertyName("customer_primary_contact")]
        public string CustomerPrimaryContact { get; set; }

        [JsonPropertyName("mobile_no")]
        public string MobileNo { get; set; }

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("tax_id")]
        public string TaxId { get; set; }

        [JsonPropertyName("tax_category")]
        public string TaxCategory { get; set; }

        [JsonPropertyName("tax_withholding_category")]
        public string TaxWithholdingCategory { get; set; }

        [JsonPropertyName("payment_terms")]
        public string PaymentTerms { get; set; }

        [JsonPropertyName("loyalty_program")]
        public string LoyaltyProgram { get; set; }

        [JsonPropertyName("loyalty_program_tier")]
        public string LoyaltyProgramTier { get; set; }

        [JsonPropertyName("default_sales_partner")]
        public string DefaultSalesPartner { get; set; }

        [JsonPropertyName("default_commission_rate")]
        public decimal DefaultCommissionRate { get; set; }

        [JsonPropertyName("so_required")]
        public int SoRequired { get; set; }

        [JsonPropertyName("dn_required")]
        public int DnRequired { get; set; }

        [JsonPropertyName("is_frozen")]
        public int IsFrozen { get; set; }

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }

        /// <summary>
        /// When on_update of customer is trigger by after_insert, this field has value 1.
        /// </summary>
        [JsonPropertyName("__run_link_triggers")]
        public int? RunLinkTriggers { get; set; }
    }
}
