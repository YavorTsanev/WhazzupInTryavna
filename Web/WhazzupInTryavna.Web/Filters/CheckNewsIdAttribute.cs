namespace WhazzupInTryavna.Web.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Services.Data.News;

    public class CheckNewsIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var newsServiceService = context.HttpContext.RequestServices.GetService<INewsService>();

            var id = 0;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
            }

            if (newsServiceService != null && !newsServiceService.IsIdExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
