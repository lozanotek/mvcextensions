namespace CustomViewEngine
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcContrib.ViewEngines;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            SetupViewEngine();
        }

        private static void SetupViewEngine()
        {
            ViewEngines.Engines.Add(new NVelocityViewEngine());
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = "" } // Parameter defaults
                );

        }
    }
}