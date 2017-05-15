using System.Web;
using System.Web.Optimization;

namespace Client
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/Client")
            .IncludeDirectory("~/app/controllers", "*.js")
            .IncludeDirectory("~/app/factories", "*.js")
            .IncludeDirectory("~/app/services", "*.js")
            .IncludeDirectory("~/app/filters", "*.js")
            .Include("~/app/client.js"));
        }
    }
}
