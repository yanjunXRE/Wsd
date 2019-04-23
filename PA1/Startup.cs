using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PA1.Startup))]
namespace PA1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
