using BookCatalog.Portal.Helpers.KnownValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace BookCatalog.Portal.Helpers.Extentions
{
    public static class MvcHtmlStringExtentions
    {
        public static MvcHtmlString Glyphicon(this HtmlHelper htmlHelper, Glyphicon icon, object htmlAttributes = null)
        {
            var i = new TagBuilder("i");

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            i.MergeAttributes(attrs);

            i.AddCssClass("fas");
            i.AddCssClass("fa-" + icon.ToStringValue());

            return MvcHtmlString.Create(i.ToString());
        }

        public static MvcHtmlString ActionGlyphiconLink(this HtmlHelper htmlHelper, string linkText, Glyphicon icon, string actionName, object htmlAttributes)
        {
            var glyphicon = htmlHelper.Glyphicon(icon, new { @class = "mr-1" });
            string glyphiconHtml = glyphicon.ToHtmlString();
                                    
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName: actionName);
            
            var a = new TagBuilder("a");
            a.InnerHtml = string.Format("{0}{1}", glyphiconHtml, linkText);
            a.MergeAttribute(key: "href", value: url);

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            a.MergeAttributes(attrs);
            
            return MvcHtmlString.Create(a.ToString());
        }
    }
}