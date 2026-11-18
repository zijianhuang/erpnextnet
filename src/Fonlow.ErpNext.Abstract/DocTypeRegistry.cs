using Fonlow.ErpNext.Models;
using System.Reflection;

namespace Fonlow.ErpNext.Abstract
{
    /// <summary>
    /// Used in other help class or function to get DocType's doctype name like "Sales Order" according to ErpNextDocTypeAttribute.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class DocTypeName
    {
        public static string Get<T>() {return Get(typeof(T)); }

        public static string Get(Type type)
        {
            return type.GetCustomAttribute<ErpNextDocTypeAttribute>(inherit: true)?.Name
            ?? throw new InvalidOperationException($"{type.Name} lacks [ErpNextDocType].");
        }
    }
}
