using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal.Helpers.Optimization.Scripts
{
    static class Main
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/scripts/main")
                    .Include(
                            "~/Scripts/Main/config.js",
                            "~/Scripts/Main/validation.js",
                            "~/Scripts/Main/nav-menu.js",
                            "~/Scripts/Main/loading-spinner.js",
                            "~/Scripts/Main/ajax-global.js",
                            "~/Scripts/Main/modal.js",
                            "~/Scripts/Main/data-grid.js"
                            )
                );
        }
    }
}