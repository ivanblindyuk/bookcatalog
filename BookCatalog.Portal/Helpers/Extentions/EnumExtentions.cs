using BookCatalog.Portal.Helpers.KnownValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BookCatalog.Portal.Helpers.Extentions
{
    public static class EnumExtentions
    {
        public static string ToStringValue(this Glyphicon icon)
        {
            string output = string.Empty;
            Type type = icon.GetType();
            
            FieldInfo fi = type.GetField(icon.ToString());
            DisplayAttribute attr = fi.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            if (attr != null)
            {
                output = attr.Name;
            }

            return output;
        }
    }
}