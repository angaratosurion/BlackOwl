using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlackOwl.Startup))]
namespace BlackOwl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
