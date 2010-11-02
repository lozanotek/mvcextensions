namespace Mvc {
    using System;
    using System.Web.Routing;

    public static class RouteExtension {
        public static T GetRouteValue<T>(this RouteValueDictionary routeValues, string key, T defaultValue) {
            if (routeValues.ContainsKey(key)) {
                var value = routeValues[key];
                return (T) Convert.ChangeType(value, typeof (T));
            }

            return defaultValue;
        }
    }
}
