namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Contact;
    using Xunit;

    public class ContactControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnView()
        {
            MyController<ContactController>
                .Instance()
                .WithUser()
                .Calling(x => x.Index())
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void PostIndexWithValidModelStateAndTempDataShouldRedirect()
        {
            MyController<ContactController>
                .Instance(x => x.WithUser())
                .Calling(x => x.Index(new ContactFormModel
                {
                    Email = "onq_koi_e@abv.bg",
                    Message = "TestMessage",
                    Name = "TestName",
                    Subject = "Test",
                }))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .TempData(x => x.ContainingEntryWithKey("SuccessSentEmail"))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Index");
        }

        [Fact]
        public void PostIndexWithInvalidModelStateShouldReturnViewWithCorrectModel()
        {
            MyController<ContactController>
                .Instance(x => x.WithUser())
                .Calling(x => x.Index(new ContactFormModel
                {
                    Email = "Invalid Email",
                }))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .View(x => x.WithModelOfType<ContactFormModel>()
                    .Passing(x => x.Email == "Invalid Email"));
        }
    }
}
