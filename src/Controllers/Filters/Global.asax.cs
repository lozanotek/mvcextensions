namespace Filters {
    using System.Web.Mvc;
    using System.Web.Routing;
    using DependencyInjection;
    using Filters.Controllers;
    using Filters.Filter;
    using Filters.Models;
    using Ninject;

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            
            // This is the registration for the injectable global filter 
            Globals.Run<GlobalLogging>();
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var kernel = CreateKernel();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            RegisterFilterProviders(FilterProviders.Providers, kernel);
        }

        public IKernel CreateKernel() {
            var kernel = new StandardKernel();
            kernel.Bind<IController>().To<HomeController>();
            kernel.Bind<IControllerActivator>().To<NinjectActivator>();
            kernel.Bind<ILogger>().To<Logger>();
            
            return kernel;
        }

        public static void RegisterFilterProviders(FilterProviderCollection providers, IKernel kernel) {
            // Remove the old provider since we do not want dubplicates
            providers.Remove<FilterAttributeFilterProvider>();

            // Register the provider with the MVC3 runtime
            providers.Add(new InjectableFilterProvider(kernel));
            providers.Add(new InjectableGlobalProvider(kernel));
        }
    }
}
