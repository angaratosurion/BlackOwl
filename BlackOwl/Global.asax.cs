using System;
using BlackCogs.Application;
using BlackOwl.Core;
using BlackOwl.Core.Application;

namespace BlackOwl
{
    public class MvcApplication : Application//System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                //var pluginFolders = new List<string>();

                //var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                //    "Modules")).ToList();

                //plugins.ForEach(s =>
                //{
                //    var di = new DirectoryInfo(s);
                //    pluginFolders.Add(di.Name);
                //});

                //AreaRegistration.RegisterAllAreas();
                //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                //RouteConfig.RegisterRoutes(RouteTable.Routes);
                //BundleConfig.RegisterBundles(BundleTable.Bundles);
                //Bootstrapper.Compose(pluginFolders);
                //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());               
                //ViewEngines.Engines.Add(new CustomViewEngine(pluginFolders));
                base.Application_Start();
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
            }
        }
    }
}
