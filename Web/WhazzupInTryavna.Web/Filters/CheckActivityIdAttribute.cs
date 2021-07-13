namespace WhazzupInTryavna.Web.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;

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
