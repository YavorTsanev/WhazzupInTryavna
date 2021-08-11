using WhazzupInTryavna.Data.Models.Activities;

namespace WhazzupInTryavna.IntegrationTests.Data.Mocks
{
    using System;
    using Moq;

    public class ActivityMocks
    {
        public static Activity Create
        {
            get
            {
                var moq = new Mock<Activity>();

                moq.Setup(a => a.Id).Returns(2);
                moq.Setup(a => a.Name).Returns("TestName");
                moq.Setup(a => a.Location).Returns("TestLocation");
                moq.Setup(a => a.StartTime).Returns(DateTime.Now);

                return moq.Object;
            }
        }
    }
}
