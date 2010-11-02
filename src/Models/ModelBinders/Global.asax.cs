namespace ModelBinders
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Model;
    using Mvc;

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes) {

            ModelBinders.Binders.Add(typeof(PersonViewModel), new PersonViewModelBinder());
            ModelBinders.Binders.Add(typeof(PersonInputModel), new PersonInputModelBinder());

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("personList", "{year}/{month}/{day}", 
                new { controller = "Home", action = "List", id = "" }  
            ); 

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
