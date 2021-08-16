namespace WhazzupInTryavna.IntegrationTests.Routing.AdminControllerTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Categories;
    using Xunit;

    public class CategoriesControllerTests
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Categories/All")
                .To<CategoriesController>(c => c.All());
        }

        [Fact]
        public void GetAddRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Categories/Add")
                .To<CategoriesController>(c => c.Add());
        }

        [Fact]
        public void PostAddRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Administration/Categories/Add")
                    .WithMethod(HttpMethod.Post))
                .To<CategoriesController>(c => c.Add(With.Any<CategoryFormModel>()));
        }

        [Fact]
        public void GetEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Categories/Edit")
                .To<CategoriesController>(c => c.Edit(With.Any<int>()));
        }

        [Fact]
        public void PostEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Administration/Categories/Edit")
                    .WithMethod(HttpMethod.Post))
                .To<CategoriesController>(c => c.Edit(With.Any<int>(), With.Any<CategoryEditViewModel>()));
        }

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Categories/Delete")
                .To<CategoriesController>(c => c.Delete(With.Any<int>()));
        }
    }
}
