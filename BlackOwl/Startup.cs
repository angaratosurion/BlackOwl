using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackOwl.Startup))]
namespace BlackOwl
{
    public partial class Startup: BlackOwl.Core.Application.Startup
    {
        public void Configuration(IAppBuilder app)
        {
            base.ConfigureAuth(app);
            ConfigureAuth(app);
        }
    }
}
