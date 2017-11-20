using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideGo.Startup))]
namespace VideGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
