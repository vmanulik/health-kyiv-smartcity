using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthSmartCity.UI.Startup))]
namespace HealthSmartCity.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
