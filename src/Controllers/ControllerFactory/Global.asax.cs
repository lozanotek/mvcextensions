namespace ControllerFactory {
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using ControllerFactory.Models;
    using Controllers;
    using DependencyInjection;
    using Ninject;

    public class MvcApplication : HttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = "" } // Parameter defaults
                );
        }

        protected void Application_Start() {
            RegisterRoutes(RouteTable.Routes);

            var kernel = CreateKernel();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public IKernel CreateKernel() {
            var kernel = new StandardKernel();
            kernel.Bind<IController>().To<HomeController>();
            kernel.Bind<IControllerActivator>().To<NinjectActivator>();
            kernel.Bind<IMessageProvider>().To<MessageProvider>();
            return kernel;
        }
    }
}
