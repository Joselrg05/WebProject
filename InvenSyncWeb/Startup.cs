using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvenSyncWeb.Startup))]
namespace InvenSyncWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
