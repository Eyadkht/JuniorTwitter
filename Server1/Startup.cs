using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Server1.Startup))]
namespace Server1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
