namespace WhazzupInTryavna.Web.ViewModels.Administration.Activities
{
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public class ActivityAdminEditViewModel : ActivityEditViewModel, IMapFrom<Activity>
    {
    }
}
