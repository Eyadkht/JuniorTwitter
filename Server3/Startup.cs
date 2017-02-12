using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Server3.Startup))]
namespace Server3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
