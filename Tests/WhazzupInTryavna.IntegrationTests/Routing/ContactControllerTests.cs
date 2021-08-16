namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Contact;
    using Xunit;

    public class ContactControllerTests
    {
        [Fact]
        public void GetIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Contact/Index")
                .To<ContactController>(c => c.Index());
        }

        [Fact]
        public void PostIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Contact/Index")
                    .WithMethod(HttpMethod.Post))
                .To<ContactController>(c => c.Index(With.Any<ContactFormModel>()));
        }
    }
}
