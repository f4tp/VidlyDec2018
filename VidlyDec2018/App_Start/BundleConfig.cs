using System.Web;
using System.Web.Optimization;

namespace VidlyDec2018
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //this is now called lib, script reference has been added to teh bottom of layout shared html
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/bootstrap.js",
                      //below was added when used package manager to install package-install bootbox -version 4.3.0
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                      //below are required for data tables... also need to datatables style sheet to CSS bundle below
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables/bootstrap.js",
                      "~/Scripts/typeahead.bundle.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            /*
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      //below was added when used package manager to install package-install bootbox -version 4.3.0
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));
           */

            bundles.Add(new StyleBundle("~/Content/css").Include(
                //was -lumen
                      "~/Content/bootstrap-lumen.css",
                      //added below for datatables css
                      //these make datatables look like the bootstrap tables
                      "~/Content/dataTables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/site.css"
                      
                      ));
        }
    }
}
