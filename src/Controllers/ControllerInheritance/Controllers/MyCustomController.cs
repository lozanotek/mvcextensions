namespace ControllerInheritance.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class MyCustomController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            MyBaseController controller = new MyBaseController();

            controller.TempData.Load(controller.ControllerContext, controller.TempDataProvider);
            try
            {
                string requiredString = controller.RouteData.GetRequiredString("action");
                if (!controller.ActionInvoker.InvokeAction(controller.ControllerContext, requiredString))
                {
                    throw new Exception("oh no!");
                }
            }
            finally
            {
                controller.TempData.Save(controller.ControllerContext, controller.TempDataProvider);
            }
        }
    }
}