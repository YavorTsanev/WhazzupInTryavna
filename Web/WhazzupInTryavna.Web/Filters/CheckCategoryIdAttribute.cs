namespace WhazzupInTryavna.Web.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Services.Data.Category;

    public class CheckCategoryIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var categoryService = context.HttpContext.RequestServices.GetService<ICategoryService>();

            var id = 0;

            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
            }

            if (categoryService != null && !categoryService.IsIdExist(id))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
