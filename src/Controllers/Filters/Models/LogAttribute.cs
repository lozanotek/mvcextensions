namespace Filters.Models
{
    using System.Web.Mvc;
    using Ninject;

    public class LogAttribute : ActionFilterAttribute {
        // Tell Ninject to inject the type
        [Inject]
        public ILogger Logger { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;

            string message = string.Format("[ATTRIB] -- About to execute '{0}.{1}'.", controller, action);
            Logger.Log(message);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;

            string message = string.Format("[ATTRIB] -- Executed '{0}.{1}'.", controller, action);
            Logger.Log(message);
        }
    }
}
