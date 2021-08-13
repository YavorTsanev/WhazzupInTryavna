namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class ChatControllerTests
    {
        [Fact]
        public void ChatControllerShouldReturnView()
        {
            MyController<ChatController>
                .Instance()
                .WithUser()
                .Calling(x => x.Chat())
                .ShouldReturn()
                .View();
        }
    }
}
