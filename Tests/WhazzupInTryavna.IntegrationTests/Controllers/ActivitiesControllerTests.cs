using System;
using System.Collections.Generic;
using System.Linq;
using WhazzupInTryavna.Web.ViewModels.Activities;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetAddShouldReturnView()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(c => c.Add())
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityFormModel>());
        }
    }
}
