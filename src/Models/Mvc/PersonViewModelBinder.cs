namespace Mvc {
    using System;
    using System.Web.Mvc;
    using Model;

    public class PersonViewModelBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var form = controllerContext.HttpContext.Request.Form;
            var person = new PersonViewModel();
            var firstName = form["FirstName"];
            var lastName = form["LastName"];

            var day = form["day"] ?? "1";
            var month = form["month"] ?? "1";
            var year = form["year"] ?? "2009";

            if (string.IsNullOrEmpty(firstName)) {
                bindingContext.ModelState.AddModelError("firstname", "First name cannot be empty.");
            }

            if (string.IsNullOrEmpty(lastName)) {
                bindingContext.ModelState.AddModelError("lastName", "Last name cannot be empty.");
            }

            person.FirstName = firstName;
            person.LastName = lastName;
            person.Birthdate = new DateTime(year.ToInt32(), month.ToInt32(), day.ToInt32());

            return person;
        }
    }
}
