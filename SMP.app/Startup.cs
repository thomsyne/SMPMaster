using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMP.app.Startup))]
namespace SMP.app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
