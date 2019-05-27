using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessTripAdvisor.Startup))]
namespace BusinessTripAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
