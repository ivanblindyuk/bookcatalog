using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal.Helpers.Optimization.Scripts
{
    static class KO
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/scripts/ko")
                    .Include(
                            "~/Scripts/KO/bindings.js",
                            "~/Scripts/KO/validation-rules.js",
                            "~/Scripts/KO/settings.js"
                            )
                );
        }
    }
}