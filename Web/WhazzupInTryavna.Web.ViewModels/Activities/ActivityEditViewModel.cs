namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class ActivityEditViewModel : ActivityAddViewModel, IMapFrom<Activity>
    {
    }
}
