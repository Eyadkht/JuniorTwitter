using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Server2.Startup))]
namespace Server2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
