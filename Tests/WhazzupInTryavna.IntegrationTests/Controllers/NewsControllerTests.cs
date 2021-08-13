namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using System;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.News;
    using Xunit;

    public class NewsControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnViewWithModel()
        {
            MyController<NewsController>
                .Instance()
                .WithUser()
                .Calling(x => x.Index())
                .ShouldReturn()
                .View(v => v.WithModelOfType<NewsListingViewModel>());
        }

        [Fact]
        public void GetDetailsWithValidInformationShouldReturnViewWithModel()
        {
            MyController<NewsController>
                .Instance(x => x.WithData(new News
                {
                    Id = 2,
                    Content = "TestContent",
                    Date = DateTime.Now,
                    ImageUrl = "TestImage.png",
                    Title = "TestTitle",
                }))
                .Calling(x => x.Details(2, "TestTitle"))
                .ShouldReturn()
                .View(v => v.WithModelOfType<DetailsViewModel>());
        }

        [Fact]
        public void GetDetailsWithInvalidInformationShouldReturnBadRequest()
        {
            MyController<NewsController>
                .Instance(x => x.WithData(new News
                {
                    Id = 2,
                    Content = "TestContent",
                    Date = DateTime.Now,
                    ImageUrl = "TestImage.png",
                    Title = "TestTitle",
                }))
                .Calling(x => x.Details(2, "InvalidTestTitle"))
                .ShouldReturn()
                .BadRequest();
        }
    }
}
