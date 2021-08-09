using MyTested.AspNetCore.Mvc;
using WhazzupInTryavna.Web.Controllers;
using Xunit;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    public class ActivitiesControllerTests
    {
        [Fact]

        public void GetAddShouldReturnView()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(c => c.Add())
                .ShouldReturn()
                .View();
        }
    }
}
