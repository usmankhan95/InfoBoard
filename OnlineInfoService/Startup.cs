using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineInfoService.Startup))]
namespace OnlineInfoService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
