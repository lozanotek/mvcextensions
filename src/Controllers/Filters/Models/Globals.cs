namespace Filters.Models {
    using System;
    using System.Collections.Generic;

    public static class Globals {
        private static readonly IList<Type> globalList = new List<Type>();

        public static void Run<TFilter>() where TFilter : class {
            Run(typeof (TFilter));
        }

        public static void Run(Type filter) {
            globalList.Add(filter);
        }
 
        public static IEnumerable<Type> GetTypes() {
            return globalList;
        }
    }
}