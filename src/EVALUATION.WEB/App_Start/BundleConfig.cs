using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace EVALUATION.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));



            /*bundles.Add(new ScriptBundle("~/bundles/webcomponents").Include(
              "~/lib/components/vendors/bower_components/webcomponentslib/webcomponentsjs/webcomponents-lite.js"
              ));*/

          

            bundles.Add(new ScriptBundle("~/bundles/utilities").Include(
              "~/lib/components/common/utilities.js"
              ));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
              "~/Scripts/index.js"
              ));

            bundles.Add(new StyleBundle("~/Content/index").Include(
                 "~/lib/bower_components/bootstrap/dist/css/bootstrap.css",
                 "~/Content/animate.css",
                 "~/Content/font-awesome.min.css",
                 "~/Content/simple-line-icons.css",
                 "~/Content/font.css",
                 "~/Content/app.css",
                 "~/lib/bower_components/angular-dialog-service/dialogs.min.css",
                 "~/lib/manual_loaded_libs/gritter/css/jquery.gritter.css"));

            bundles.Add(new ScriptBundle("~/bundles/require").Include(
              "~/lib/bower_components/requirejs/require.js"
              ));

            /*var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
           .Include(ANGULAR_APP_ROOT + "app.js")
           .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true);*/

            /**Core test**/
            /*bundles.Add(new ScriptBundle("~/bundles/source").Include(
             "~/modules/Core/config/CoreInstallFeatures.js"
             ));*/






            /**MODULES**/
            //bundles.Add(new ScriptBundle("~/bundles/source").IncludeDirectory("~/modules/garant/features", "*.js",searchSubdirectories:true));
            //bundles.Add(new ScriptBundle("~/bundles/source").Include("~/modules/garant/features/administration/garantAdministrationListCtrl.js"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
