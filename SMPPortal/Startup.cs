using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMPPortal.Startup))]
namespace SMPPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
