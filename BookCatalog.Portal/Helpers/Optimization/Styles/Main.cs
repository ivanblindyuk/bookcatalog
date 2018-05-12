using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal.Helpers.Optimization.Styles
{
    static class Main
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/bundles/styles/main")
                    .Include(
                            "~/Styles/main.css"
                            )
                );
        }
    }
}