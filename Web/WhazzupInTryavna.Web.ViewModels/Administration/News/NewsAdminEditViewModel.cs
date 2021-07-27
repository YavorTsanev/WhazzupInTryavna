namespace WhazzupInTryavna.Web.ViewModels.Administration.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.News;

    public class NewsAdminEditViewModel : NewsBaseViewModel, IMapFrom<News>
    {
    }
}
