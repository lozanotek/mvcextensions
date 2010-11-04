namespace Filters.Models {
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ninject;

    public class InjectableGlobalProvider : IFilterProvider {
        public IKernel Kernel { get; private set; }

        public InjectableGlobalProvider(IKernel kernel) {
            Kernel = kernel;            
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            var types = Globals.GetTypes();
            var filters = new List<Filter>();
            
            foreach (var type in types) {
                var instance = Kernel.Get(type);

                filters.Add(new Filter(instance, FilterScope.Global));
            }

            return filters;
        }
    }
}