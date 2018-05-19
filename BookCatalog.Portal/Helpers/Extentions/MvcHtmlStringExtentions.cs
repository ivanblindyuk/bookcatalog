using BookCatalog.Portal.Helpers.KnownValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Script.Serialization;

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
            i.AddCssClass("fa-fw");
            i.AddCssClass("fa-" + icon.ToStringValue());

            return MvcHtmlString.Create(i.ToString());
        }

        public static MvcHtmlString ActionGlyphiconLink(this HtmlHelper htmlHelper, string linkText, Glyphicon icon, string actionName, object routeValues, object htmlAttributes)
        {
            object icoHtmlAttributes = null;
            if (!string.IsNullOrEmpty(linkText)) icoHtmlAttributes = new { @class = "mr-1" };

            var glyphicon = htmlHelper.Glyphicon(icon, icoHtmlAttributes);
            string glyphiconHtml = glyphicon.ToHtmlString();
                                    
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, routeValues);
            
            var a = new TagBuilder("a");
            a.InnerHtml = string.Format("{0}{1}", glyphiconHtml, linkText);
            a.MergeAttribute(key: "href", value: url);

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            a.MergeAttributes(attrs);
            
            return MvcHtmlString.Create(a.ToString());
        }

        public static MvcHtmlString ActionGlyphiconLink(this HtmlHelper htmlHelper, string linkText, Glyphicon icon, string actionName, object htmlAttributes = null)
        {
            return ActionGlyphiconLink(htmlHelper, linkText, icon, actionName, null, htmlAttributes);
        }

        public static MvcHtmlString ButtonGlyphicon(this HtmlHelper htmlHelper, string text, Glyphicon icon, object htmlAttributes = null)
        {
            object icoHtmlAttributes = null;
            if (!string.IsNullOrEmpty(text)) icoHtmlAttributes = new { @class = "mr-1" };

            var glyphicon = htmlHelper.Glyphicon(icon, icoHtmlAttributes);
            string glyphiconHtml = glyphicon.ToHtmlString();
            
            var button = new TagBuilder("button");
            button.InnerHtml = string.Format("{0}{1}", glyphiconHtml, text);

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            button.MergeAttributes(attrs);

            return MvcHtmlString.Create(button.ToString());
        }

        public static string AsJson(this HtmlHelper htmlHelper, object model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(model);
        }
    }
}