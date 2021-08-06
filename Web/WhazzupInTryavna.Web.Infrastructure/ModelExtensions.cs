using WhazzupInTryavna.Web.ViewModels.Activities;

namespace WhazzupInTryavna.Web.Infrastructure
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IActivityModel model)
        {
            return model.Name + "-" + model.Location;
        }
    }
}
