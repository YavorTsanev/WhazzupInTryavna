namespace WhazzupInTryavna.Web.Infrastructure
{
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public static class ModelExtensions
    {
        public static string GetInformation(this IActivityModel model)
        {
            return model.Name + "-" + model.Location;
        }
    }
}
