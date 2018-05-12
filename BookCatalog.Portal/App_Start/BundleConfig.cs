using ScriptBundles = BookCatalog.Portal.Helpers.Optimization.Scripts;
using StyleBundles = BookCatalog.Portal.Helpers.Optimization.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookCatalog.Portal
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);
        }

        static void RegisterScriptBundles(BundleCollection bundles)
        {
            ScriptBundles.Main.RegisterBundle(bundles);
            ScriptBundles.Books.RegisterBundles(bundles);
            ScriptBundles.Authors.RegisterBundles(bundles);
        }

        static void RegisterStyleBundles(BundleCollection bundles)
        {
            StyleBundles.Main.RegisterBundle(bundles);
        }
    }
}