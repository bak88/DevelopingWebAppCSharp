using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace lecture1._2_WebAPI.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var message = $"Executing action {actionName} on controller {controllerName}.\n";

            File.AppendAllText("/Users/dimba/source/repos/DevelopingWebAppCSharp/lecture1.2_WebAPI/obj/Debug/net8.0/log.txt", message);

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var message = $"Executing action {actionName} on controller {controllerName}.\n";

            File.AppendAllText("/Users/dimba/source/repos/DevelopingWebAppCSharp/lecture1.2_WebAPI/obj/Debug/net8.0/log.txt", message);

            base.OnActionExecuted(context);
        }
    }
}
