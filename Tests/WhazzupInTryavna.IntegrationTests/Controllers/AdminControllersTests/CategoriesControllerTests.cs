namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Categories;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.CategoryData;

    public class CategoriesControllerTests
    {
        [Fact]
        public void GetAddShouldReturnView()
        {
            MyController<CategoriesController>
                .Instance()
                .Calling(x => x.Add())
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void PostAddShouldRedirectWithValidModelState()
        {
            MyController<CategoriesController>
                .Instance(x => x
                    .WithData(GetSingleCategory()))
                .Calling(x => x.Add(new CategoryFormModel
                {
                    Image = "TestImage.png",
                    Name = "TestName",
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(x => x.WithSet<Category>(d => d.Any(c =>
                    c.Image == "TestImage.png" &&
                    c.Name == "TestName")))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void PostAddShouldReturnViewWithCorrectModelWithInvalidModelState()
        {
            MyController<CategoriesController>
                .Instance()
                .Calling(a => a.Add(new CategoryFormModel()))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<CategoryFormModel>()
                    .Passing(x => x.Name == null && x.Image == null));
        }

        [Fact]
        public void GetAllShouldReturnViewWithCorrectModel()
        {
            MyController<CategoriesController>
                .Instance(x => x
                    .WithData(GetSingleCategory()))
                .Calling(x => x.All())
                .ShouldReturn()
                .View(v => v.WithModelOfType<CategoriesListingViewModel>()
                    .Passing(x => x.Categories.Any(c =>
                        c.Name == "Test" && c.Image == "testImage.png")));
        }

        [Fact]
        public void GetEditShouldReturnViewWithCorrectModel()
        {
            MyController<CategoriesController>
                .Instance(x => x
                    .WithData(GetSingleCategory()))
                .Calling(x => x.Edit(3))
                .ShouldReturn()
                .View(v => v.WithModelOfType<CategoryEditViewModel>()
                .Passing(x => x.Image == "testImage.png" && x.Name == "Test"));
        }

        [Fact]
        public void PostEditShouldRedirectWithValidModelState()
        {
            MyController<CategoriesController>
                .Instance(x => x
                    .WithData(GetSingleCategory()))
                .Calling(x => x.Edit(3, new CategoryEditViewModel
                {
                    Name = "Edit",
                    Image = "Edit.png",
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(x => x.WithSet<Category>(d => d.Any(c =>
                    c.Name == "Edit" &&
                    c.Image == "Edit.png")))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void GetDeleteShouldDeleteCategoryByIdAndRedirect()
        {
            MyController<CategoriesController>
                .Instance(x => x
                    .WithData(GetSingleCategory()))
                .Calling(x => x.Delete(3))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
