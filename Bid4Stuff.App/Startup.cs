using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bid4Stuff.App.Startup))]
namespace Bid4Stuff.App
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
