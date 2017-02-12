using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bootstrap3.Startup))]
namespace Bootstrap3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
