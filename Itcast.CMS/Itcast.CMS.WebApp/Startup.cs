using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Itcast.CMS.WebApp.Startup))]
namespace Itcast.CMS.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
