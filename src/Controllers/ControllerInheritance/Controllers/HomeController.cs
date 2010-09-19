namespace ControllerInheritance.Controllers
{
    using System.Web.Mvc;

    [HandleError]
    public class HomeController : MyBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}