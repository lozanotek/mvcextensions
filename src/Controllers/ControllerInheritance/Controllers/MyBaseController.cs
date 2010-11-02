namespace ControllerInheritance.Controllers {
    using System.Web.Mvc;

    public class MyBaseController : Controller {
        public static int ExecutionCount { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
            ViewData["ExecutionMessage"] = string.Format("Total executions: {0}", ExecutionCount++);
        }
    }
}
