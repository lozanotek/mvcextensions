namespace ControllerFactory.Controllers {
    using System.Web.Mvc;
    using ControllerFactory.Models;

    [HandleError]
    public class HomeController : Controller {
        public HomeController(IMessageProvider provider) {
            Provider = provider;
        }

        private IMessageProvider Provider { get; set; }

        public string ExecutionMessage {
            get { return "I'm a FooController and " + Provider.GetMessage(); }
        }

        public ActionResult Index() {
            ViewData["Message"] = ExecutionMessage;
            return View();
        }

        public ActionResult About() {
            var result = Index();
            return result;
        }
    }
}
