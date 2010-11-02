namespace ControllerFactory.Controllers {
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using ControllerFactory.Models;

    public class CustomControllerFactory : DefaultControllerFactory {
        private static readonly IMessageProvider defaultProvider = new MessageProvider();

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            return new HomeController(defaultProvider);
        }
    }
}
