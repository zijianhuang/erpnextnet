using System.Collections;

namespace Fonlow.ErpNext
{
    /// <summary>
    /// Represents a fluent builder for constructing API query parameter strings that combine filters, field selections,
    /// limits, and ordering.
    /// </summary>
    /// <remarks>Build returns the query component without a leading '?'. Filter expressions are formatted as
    /// JSON-like arrays and combined into a filters=[...] element; field selections, limits, and order clauses are
    /// added as other query elements. Link names are URL-escaped when added. Instances support fluent
    /// chaining.</remarks>
    public class Filters
    {
        readonly List<string> conditions = new List<string>();
        readonly List<string> filters = new List<string>();


        public static Filters Create()
        {
            return new Filters();
        }

        public string Build()
        {
            if (filters.Count > 0)
            {
                var filetersText = $"filters=[{string.Join(", ", filters)}]";
                conditions.Add(filetersText);
            }

            return string.Join("&", conditions);
        }

        public Filters AddLimitStart(int limitStart)
        {
            conditions.Add($"limit_start={limitStart}");
            return this;
        }

        /// <summary>
        /// 0 means all
        /// </summary>
        /// <param name="limitPageLenth"></param>
        /// <returns></returns>
        public Filters AddLimitPageLength(int limitPageLenth)
        {
            conditions.Add($"limit_page_length={limitPageLenth}");
            return this;
        }

        public Filters IncludeAllFields()
        {
            conditions.Add("fields=[\"*\"]");
            return this;
        }

        public Filters IncludeFields(string[] fields)
        {
            var fieldsText = string.Join(", ", fields.Select(d => $"\"{d}\""));
            conditions.Add($"fields=[{fieldsText}]");
            return this;
        }


        /// <summary>
        /// For getting dynamic linked data like addresses of customer, or contact of customer, including all field, like:
        /// api/resource/Address?filters=[["Dynamic Link","link_doctype","=","Customer"],["Dynamic Link","link_name","=","Flick - Bendigo"]]ANDfields=["*"]
        /// </summary>
        /// <param name="link_doctype"></param>
        /// <param name="link_name"></param>
        /// <returns></returns>
        public Filters AddLinkedDocType(string link_doctype, string link_name)
        {
            filters.Add($"[\"Dynamic Link\",\"link_doctype\",\"=\",\"{link_doctype}\"]");
            filters.Add($"[\"Dynamic Link\",\"link_name\",\"=\",\"{Uri.EscapeDataString(link_name)}\"]");
            return this;
        }

        public Filters AddNumberFieldFilter(string fieldName, int fieldValue)
        {
            filters.Add($"[\"{fieldName}\",\"=\",{fieldValue}]");
            return this;
        }

        public Filters AddStringFieldFilter(string fieldName, string fieldValue)
        {
            AddStringFieldFilter(fieldName, fieldValue, "=");
            return this;
        }

        public Filters AddStringFieldNotEqualFilter(string fieldName, string fieldValue)
        {
            AddStringFieldFilter(fieldName, fieldValue, "!=");
            return this;
        }

        public Filters AddStringFieldLikeFilter(string fieldName, string fieldValue)
        {
            filters.Add($"[\"{fieldName}\",\"like\",\"%25{fieldValue}%25\"]");
            return this;
        }

        Filters AddStringFieldFilter(string fieldName, string fieldValue, string comparer)
        {
            filters.Add($"[\"{fieldName}\",\"{comparer}\",\"{fieldValue}\"]");
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <param name="subTable">child table doctype name like "Maintenance Visit Purpose" </param>
        /// <returns></returns>
        public Filters AddStringFieldOfSubTableLikeFilter(string fieldName, string fieldValue, string subTable)
        {
            filters.Add($"[\"{subTable}\",\"{fieldName}\",\"like\",\"%25{fieldValue}%25\"]");
            return this;
        }

        public Filters AddStringFieldOfSubTableEqualFilter(string fieldName, string fieldValue, string subTable)
        {
            AddStringFieldOfSubTableFilter(fieldName, fieldValue, subTable, "=");
            return this;
        }

        public Filters AddlStringFieldOfSubTableNotEqualFilter(string fieldName, string fieldValue, string subTable)
        {
            AddStringFieldOfSubTableFilter(fieldName, fieldValue, subTable, "!=");
            return this;
        }

        Filters AddStringFieldOfSubTableFilter(string fieldName, string fieldValue, string subTable, string comparer)
        {
            filters.Add($"[\"{subTable}\",\"{fieldName}\",\"{comparer}\",\"{fieldValue}\"]");
            return this;
        }

        public Filters Orderby(string fieldName, bool isAsc = true)
        {
            conditions.Add($"order_by={fieldName} {(isAsc ? "asc" : "desc")}");
            return this;
        }

        public static readonly string AllFields = "fields=[\"*\"]";
    }

}
