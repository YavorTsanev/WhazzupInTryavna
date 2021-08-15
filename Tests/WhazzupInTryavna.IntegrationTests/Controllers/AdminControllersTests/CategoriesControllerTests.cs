using System.Linq;
using WhazzupInTryavna.Data.Models.Activities;

namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using MyTested.AspNetCore.Mvc;
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
                .Data(x => x.WithSet<Category>(x => x.Any(c =>
                    c.Image == "TestImage.png" &&
                    c.Name == "TestName")))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void PostAddShouldReturnViewWithModelWithInvalidModelState()
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
        public void GetAllShouldReturnViewWithModel()
        {
            MyController<CategoriesController>
                .Instance(x => x.WithData(GetSingleCategory()))
                .Calling(x => x.All())
                .ShouldReturn()
                .View(x => x.WithModelOfType<CategoriesListingViewModel>()
                    .Passing(x => x.Categories.Any(c => 
                        c.Name == "Test" && c.Image == "testImage.png")));
        }

        [Fact]
        public void GetEditShouldReturnViewWithModel()
        {
            MyController<CategoriesController>
                .Instance(x => x.WithData(GetSingleCategory()))
                .Calling(x => x.Edit(3))
                .ShouldReturn()
                .View(x => x.WithModelOfType<CategoryEditViewModel>()
                .Passing(x => x.Image == "testImage.png" && x.Name == "Test"));
        }

        [Fact]
        public void PostEditShouldRedirectWithValidModelState()
        {
            MyController<CategoriesController>
                .Instance(x => x.WithData(GetSingleCategory()))
                .Calling(x => x.Edit(3, new CategoryEditViewModel
                {
                    Name = "Edit",
                    Image = "Edit.png",
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(x => x.WithSet<Category>(x => x.Any(c => 
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
                .Instance(x => x.WithData(GetSingleCategory()))
                .Calling(x => x.Delete(3))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
