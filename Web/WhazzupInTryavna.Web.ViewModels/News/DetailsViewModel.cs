namespace WhazzupInTryavna.Web.ViewModels.News
{
    using System;

    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class DetailsViewModel : NewsBaseViewModel, IMapFrom<News>
    {
    }
}
