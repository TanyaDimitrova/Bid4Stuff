using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bid4StuffApp.Startup))]
namespace Bid4StuffApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
