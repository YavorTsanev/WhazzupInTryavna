namespace WhazzupInTryavna.IntegrationTests
{
    using Microsoft.Extensions.Configuration;
    using WhazzupInTryavna.Web;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) 
            : base(configuration)
        {
        }
    }
}
