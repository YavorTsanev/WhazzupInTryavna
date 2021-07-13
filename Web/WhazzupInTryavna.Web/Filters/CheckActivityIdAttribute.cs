namespace WhazzupInTryavna.Web.Filters
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Services.Data.Activity;

    public class CheckActivityIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var activityService = context.HttpContext.RequestServices.GetService<IActivityService>();

            var id = 0;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
            }

            if (activityService != null && !activityService.IsIdExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
