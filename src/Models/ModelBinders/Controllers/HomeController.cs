namespace ModelBinders.Controllers {
    using System.Web.Mvc;
    using Model;
    using Mvc;

    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            var service = new PersonService();
            var personList = service.GetPeople();

            return View(personList);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(PersonViewModelBinder))]
            PersonViewModel viewModel) {
            if (!ModelState.IsValid)
                return View();

            var service = new PersonService();
            service.Add(viewModel);

            return RedirectToAction("Index");
        }

        public ActionResult List(PersonInputModel person) {
            var service = new PersonService();
            var people = service.GetPeopleByBirthdate(person.Birthdate);
            return View(people);
        }
    }
}
