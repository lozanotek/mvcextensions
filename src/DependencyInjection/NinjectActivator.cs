namespace DependencyInjection {
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Ninject;

    public class NinjectActivator : IControllerActivator {
        public IKernel Kernel { get; private set; }

        public NinjectActivator(IKernel kernel) {
            Kernel = kernel;
        }

        public IController Create(RequestContext requestContext, Type controllerType) {
            return Kernel.Get(controllerType) as IController;
        }
    }
}
