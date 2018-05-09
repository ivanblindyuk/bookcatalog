using BookCatalog.Portal.Helpers.KnownValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Portal.Helpers.Extentions
{
    public static class EnumExtentions
    {
        public static string ToStringValue(this Glyphicon icon)
        {
            return icon.ToString("g").ToLower();
        }
    }
}