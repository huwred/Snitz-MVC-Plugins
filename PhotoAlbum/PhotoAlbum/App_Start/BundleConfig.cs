using System.Web.Optimization;

namespace PhotoAlbum
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            //bundling was causing an issue in non debug mode so disable optimization
            
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                        .Include("~/Scripts/jquery.cookie.js")
                        .Include("~/Scripts/jquery-ui.js")
                        .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                        .Include("~/Scripts/jquery.highlight-5.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-dialog.js",
                        "~/Scripts/bootstrap-switch.js", 
                        "~/Scripts/bootstrap-tabcollapse.js",
                        "~/Scripts/bootstrap-spinedit.js"));

            bundles.Add(new ScriptBundle("~/bundles/oldIEBrowsersSupport").Include(
                    "~/Scripts/respond.js",
                    "~/Scripts/html5shiv.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                            "~/Content/bootstrap.css",
                            "~/Content/bootstrap-dialog.css",
                            "~/Content/bootstrap-switch.css",
                            "~/Content/bootstrap-spinedit.css",
                            "~/Content/bootstrap-responsive.css",
                            "~/Content/font-awesome.css", "~/Content/animate.css"));

        }
    }
}