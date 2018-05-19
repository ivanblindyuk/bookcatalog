using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal.Helpers.Optimization.Scripts
{
    static class Authors
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/scripts/authors")
                    .Include(
                            "~/Scripts/Views/Authors/author-details.js",
                            "~/Scripts/Views/Authors/author-list.js"
                    )
                );
        }
    }
}