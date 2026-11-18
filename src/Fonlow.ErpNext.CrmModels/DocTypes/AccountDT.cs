using System.Text.Json.Serialization;
using Fonlow.ErpNext.Models;

namespace Fonlow.ErpNext.DocTypes
{
    [ErpNextDocType("Account")]
    public class AccountDT : DocTypeBase
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

        [JsonPropertyName("disabled")]
        public int Disabled { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("is_group")]
        public int IsGroup { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("root_type")]
        public string RootType { get; set; }

        [JsonPropertyName("report_type")]
        public string ReportType { get; set; }

        [JsonPropertyName("account_currency")]
        public string AccountCurrency { get; set; }

        [JsonPropertyName("parent_account")]
        public string ParentAccount { get; set; }

        [JsonPropertyName("account_type")]
        public string AccountType { get; set; }

        [JsonPropertyName("tax_rate")]
        public decimal TaxRate { get; set; }

        [JsonPropertyName("freeze_account")]
        public string FreezeAccount { get; set; }

        [JsonPropertyName("balance_must_be")]
        public string BalanceMustBe { get; set; }

        [JsonPropertyName("lft")]
        public int Lft { get; set; }

        [JsonPropertyName("rgt")]
        public int Rgt { get; set; }

        [JsonPropertyName("old_parent")]
        public string OldParent { get; set; }

        [JsonPropertyName("include_in_gross")]
        public int IncludeInGross { get; set; }
    }

}
