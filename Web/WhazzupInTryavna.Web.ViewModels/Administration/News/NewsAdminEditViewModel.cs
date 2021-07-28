namespace WhazzupInTryavna.Web.ViewModels.Administration.News
{
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.News;

    public class NewsAdminEditViewModel : NewsBaseViewModel, IMapFrom<News>
    {
    }
}
