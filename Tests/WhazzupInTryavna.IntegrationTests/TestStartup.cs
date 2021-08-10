using Microsoft.Extensions.DependencyInjection;

namespace WhazzupInTryavna.IntegrationTests
{
    using Microsoft.Extensions.Configuration;
    using WhazzupInTryavna.Web;
    using MyTested.AspNetCore.Mvc;

    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }
    }
}
