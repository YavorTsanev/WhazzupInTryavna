using AutoMapper;
using WhazzupInTryavna.Data.Models.Activities;
using WhazzupInTryavna.Services.Mapping;

namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    public class ActivityEditViewModel : ActivityAddViewModel, IMapFrom<Activity>
    {
    }
}
