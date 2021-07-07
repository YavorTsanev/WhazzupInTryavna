namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Services.Data.Category;

    public class CheckIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var categoryService = context.HttpContext.RequestServices.GetService<ICategoryService>();
            var id = (int)context.ActionArguments["id"];

            if (categoryService != null && !categoryService.IsIdExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
