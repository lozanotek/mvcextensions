namespace ModelBinders.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Model;
    using Mvc;

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PersonService service = new PersonService();
            var personList = service.GetPeople();

            return View(personList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [Post]
        public ActionResult Create([ModelBinder(typeof(PersonModelBinder))]
            PersonViewModel viewModel)
        {
            if (!ModelState.IsValid) return View();

            PersonService service = new PersonService();
            service.Add(viewModel);

            return RedirectToAction("Index");
        }
    }
}
