using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal.Helpers.Optimization.Scripts
{
    static class Books
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/scripts/books")
                    .Include(
                            "~/Scripts/Views/Books/book-details.js",
                            "~/Scripts/Views/Books/book-list.js"
                    )
                );
        }
    }
}