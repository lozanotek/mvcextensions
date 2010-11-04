namespace Filters.Filter {
    using System.Web.Mvc;
    using Filters.Models;

    public class GlobalLogging : IActionFilter {
        public GlobalLogging(ILogger logger) {
            Logger = logger;
        }

        public GlobalLogging() : this(new Logger()) {
        }

        public ILogger Logger { get; private set; }

        public void OnActionExecuting(ActionExecutingContext filterContext) {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;

            string message = string.Format("[GLOBAL] -- About to execute '{0}.{1}'.", controller, action);
            Logger.Log(message);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;

            string message = string.Format("[GLOBAL] -- Executed '{0}.{1}'.", controller, action);
            Logger.Log(message);
        }
    }
}
