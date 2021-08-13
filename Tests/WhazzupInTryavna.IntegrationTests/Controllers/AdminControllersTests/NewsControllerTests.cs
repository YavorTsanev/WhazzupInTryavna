using System;
using System.Linq;
using WhazzupInTryavna.Data.Models.News;

namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.News;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.NewsData;

    public class NewsControllerTests
    {
        [Fact]
        public void GetAllShouldReturnViewWithCorrectModel()
        {
            MyController<NewsController>
                .Instance(x => x
                    .WithData(GetNews()))
                .Calling(x => x.All())
                .ShouldReturn()
                .View(v => v.WithModelOfType<NewsAdminListingViewModel>()
                    .Passing(x =>
                        x.NewsList.Count() == 1 &&
                        x.NewsList.Any(n =>
                        n.Id == 5 &&
                        n.Title == "NewsTitle" &&
                        n.Content == "NewsContent" &&
                        n.ImageUrl == "News.png")));
        }

        [Fact]
        public void GetEditShouldGetNewsByIdAndReturnViewWithCorrectModel()
        {
            MyController<NewsController>
                .Instance(x => x
                    .WithData(GetNews()))
                .Calling(x => x.Edit(5))
                .ShouldReturn()
                .View(v => v.WithModelOfType<NewsAdminEditViewModel>()
                    .Passing(x =>
                        x.Title == "NewsTitle" &&
                        x.ImageUrl == "News.png" &&
                        x.Content == "NewsContent"));
        }

        [Fact]
        public void PostEditShouldUpdateNewsByIdWithValidModelStateAndRedirect()
        {
            MyController<NewsController>
                .Instance(x => x
                    .WithData(GetNews()))
                .Calling(x => x.Edit(5, new NewsAdminEditViewModel
                {
                    Title = "TestTitle",
                    ImageUrl = "Test.png",
                    Date = new DateTime(2020, 1, 1),
                    Content = "TestContent",
                }))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(x => x.WithSet<News>(x =>
                    x.Any(n =>
                    n.Title == "TestTitle" &&
                    n.ImageUrl == "Test.png" &&
                    n.Date == new DateTime(2020, 1, 1) &&
                    n.Content == "TestContent")))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void PostEditWithInvalidModelStateShouldReturnViewWithCorrectModel()
        {
            MyController<NewsController>
                .Instance()
                .Calling(x => x.Edit(5, new NewsAdminEditViewModel()))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<NewsAdminEditViewModel>()
                    .Passing(x =>
                        x.Content == null &&
                        x.ImageUrl == null));
        }

        [Fact]
        public void GetDeleteShouldDeleteNewsByIdAdnRedirect()
        {
            MyController<NewsController>
                .Instance(x => x.WithData(GetNews()))
                .Calling(x => x.Delete(5))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
