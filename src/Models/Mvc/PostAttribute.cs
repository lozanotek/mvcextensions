namespace Mvc
{
    using System.Reflection;
    using System.Web.Mvc;

    public class PostAttribute : ActionMethodSelectorAttribute
    {
        private readonly AcceptVerbsAttribute verbsAttribute;

        public PostAttribute()
        {
            verbsAttribute = new AcceptVerbsAttribute(HttpVerbs.Post);
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return verbsAttribute.IsValidForRequest(controllerContext, methodInfo);
        }
    }
}