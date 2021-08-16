namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class ChatControllerTests
    {
        [Fact]
        public void GetChatRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Chat/Chat")
                .To<ChatController>(c => c.Chat());
        }
    }
}
