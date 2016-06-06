using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web.App_Start
{
    public static class Bundles
    {
        public static void RegisterBundles( BundleCollection bundles )
        {
            bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
            "~/Scripts/libs/jquery-{version}.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jqueryui" ).Include(
                        "~/Scripts/libs/jquery-ui-{version}.js" ) );

            bundles.Add( new ScriptBundle( "~/bundles/jqueryval" ).Include(
                        "~/Scripts/libs/jquery.unobtrusive*",
                        "~/Scripts/libs/jquery.validate*" ) );
            bundles.Add( new ScriptBundle( "~/Scripts/Cart.js" ).Include( "~/Scripts/Cart.js", "~/Scripts/libs/customValidation.js" ) );
            bundles.Add( new ScriptBundle( "~/bundles/knockout" ).Include(
                 "~/Scripts/libs/knockout-{version}.js",
                 "~/Scripts/libs/knockout.validation.js" ) );
            bundles.Add(new ScriptBundle("~/Bootstrap.js").Include("~/Scripts/libs/bootstrap.min.js"));
            bundles.Add( new StyleBundle( "~/Content/css" ).Include( "~/Content/bootstrap.css", "~/Content/site.css") );
        }
    }
}