using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zaggar.Startup))]
namespace Zaggar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
