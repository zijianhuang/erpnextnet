namespace Fonlow.ErpNext.Models.DocTypes
{
    using Fonlow.ErpNext.DocTypes;
    using System;
    using System.Text.Json.Serialization;

    [ErpNextDocType("Supplier")]
    public class SupplierDT : DocTypeBase
    {
        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("creation")]
        public DateTime? Creation { get; set; }

        [JsonPropertyName("modified")]
        public DateTime? Modified { get; set; }

        [JsonPropertyName("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("docstatus")]
        public int DocStatus { get; set; }

        [JsonPropertyName("idx")]
        public int Idx { get; set; }

        [JsonPropertyName("naming_series")]
        public string NamingSeries { get; set; }

        [JsonPropertyName("supplier_name")]
        public string SupplierName { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("supplier_group")]
        public string SupplierGroup { get; set; }

        [JsonPropertyName("supplier_type")]
        public string SupplierType { get; set; }

        [JsonPropertyName("is_transporter")]
        public int IsTransporter { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonPropertyName("default_bank_account")]
        public string DefaultBankAccount { get; set; }

        [JsonPropertyName("default_price_list")]
        public string DefaultPriceList { get; set; }

        [JsonPropertyName("is_internal_supplier")]
        public int IsInternalSupplier { get; set; }

        [JsonPropertyName("represents_company")]
        public string RepresentsCompany { get; set; }

        [JsonPropertyName("supplier_details")]
        public string SupplierDetails { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("tax_id")]
        public string TaxId { get; set; }

        [JsonPropertyName("tax_category")]
        public string TaxCategory { get; set; }

        [JsonPropertyName("tax_withholding_category")]
        public string TaxWithholdingCategory { get; set; }

        [JsonPropertyName("supplier_primary_address")]
        public string SupplierPrimaryAddress { get; set; }

        [JsonPropertyName("primary_address")]
        public string PrimaryAddress { get; set; }

        [JsonPropertyName("supplier_primary_contact")]
        public string SupplierPrimaryContact { get; set; }

        [JsonPropertyName("mobile_no")]
        public string MobileNo { get; set; }

        [JsonPropertyName("email_id")]
        public string EmailId { get; set; }

        [JsonPropertyName("payment_terms")]
        public string PaymentTerms { get; set; }

        [JsonPropertyName("allow_purchase_invoice_creation_without_purchase_order")]
        public int AllowPurchaseInvoiceCreationWithoutPurchaseOrder { get; set; }

        [JsonPropertyName("allow_purchase_invoice_creation_without_purchase_receipt")]
        public int AllowPurchaseInvoiceCreationWithoutPurchaseReceipt { get; set; }

        [JsonPropertyName("is_frozen")]
        public int IsFrozen { get; set; }

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }

        [JsonPropertyName("warn_rfqs")]
        public int WarnRfqs { get; set; }

        [JsonPropertyName("warn_pos")]
        public int WarnPos { get; set; }

        [JsonPropertyName("prevent_rfqs")]
        public int PreventRfqs { get; set; }

        [JsonPropertyName("prevent_pos")]
        public int PreventPos { get; set; }

        [JsonPropertyName("on_hold")]
        public int OnHold { get; set; }

        [JsonPropertyName("hold_type")]
        public string HoldType { get; set; }

        
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        //[JsonPropertyName("portal_users")]
        //public List<object> PortalUsers { get; set; } = new();

        //[JsonPropertyName("companies")]
        //public List<object> Companies { get; set; } = new();

        //[JsonPropertyName("accounts")]
        //public List<object> Accounts { get; set; } = new();
    }
}
