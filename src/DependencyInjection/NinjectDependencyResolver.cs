namespace DependencyInjection {
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;

    public class NinjectDependencyResolver : IDependencyResolver {
        public NinjectDependencyResolver() : this(new StandardKernel()) {
        }

        public NinjectDependencyResolver(IKernel kernel) {
            Kernel = kernel;
        }

        public IKernel Kernel { get; private set; }

        public object GetService(Type serviceType) {
            try {
                return Kernel.Get(serviceType);
            }
            catch {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return Kernel.GetAll(serviceType);
        }
    }
}
