namespace WhazzupInTryavna.Web.ViewModels.News
{
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class DetailsViewModel : NewsBaseViewModel, IMapFrom<News>
    {
    }
}
