namespace Mvc {
    using System;
    using System.Web.Mvc;
    using Model;

    public class PersonInputModelBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var routeValues = controllerContext.RouteData.Values;
            var today = DateTime.Now;

            var year = routeValues.GetRouteValue("year", today.Year);
            var month = routeValues.GetRouteValue("month", today.Month);
            var day = routeValues.GetRouteValue("day", today.Day);

            return new PersonInputModel {Birthdate = new DateTime(year, month, day)};
        }
    }
}