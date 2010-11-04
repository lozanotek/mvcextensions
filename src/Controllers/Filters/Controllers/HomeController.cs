namespace Filters.Controllers {
    using System.Web.Mvc;
    using Filters.Models;

    public class HomeController : Controller {
        public HomeController(ILogger logger) {
            Logger = logger;
        }

        public ILogger Logger { get; private set; }

        [Log]
        public ActionResult Index() {
            ViewModel.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [Log]
        public ActionResult About() {
            return View();
        }

        public ActionResult List() {
            var logs = Logger.GetMessages();
            return View(logs);
        }
    }
}
