using System.Linq;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using System;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.News;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.NewsData;

    public class NewsControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnViewWithCorrectModel()
        {
            MyController<NewsController>
                .Instance()
                .Calling(x => x.Index())
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void GetDetailsShouldGetNewsByIdWithValidInformationAndReturnViewWitCorrectModel()
        {
            MyController<NewsController>
                .Instance(x => x
                    .WithData(GetNews()))
                .Calling(x => x.Details(5, "NewsTitle"))
                .ShouldReturn()
                .View(v => v.WithModelOfType<DetailsViewModel>()
                    .Passing(x => x.Content == "NewsContent" &&
                                  x.Date == new DateTime(2021, 8, 13) &&
                                  x.ImageUrl == "News.png" &&
                                  x.Title == "NewsTitle"));
        }

        [Fact]
        public void GetDetailsWithInvalidInformationShouldReturnBadRequest()
        {
            MyController<NewsController>
                .Instance(x => x
                    .WithData(GetNews()))
                .Calling(x => x.Details(5, "InvalidTestTitle"))
                .ShouldReturn()
                .BadRequest();
        }
    }
}
