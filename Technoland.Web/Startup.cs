using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Technoland.Web.Startup))]
namespace Technoland.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
