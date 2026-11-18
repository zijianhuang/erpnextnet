namespace Fonlow.ErpNext.Models
{
    /// <summary>
    /// To decorate each ErpNext DocType. So the data model is the only source of truth when mapping POCO class and the doc type name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ErpNextDocTypeAttribute : Attribute
    {
        public string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">DocType's doctype value like "Sales Order"</param>
        public ErpNextDocTypeAttribute(string name) => Name = name;
    }

}
