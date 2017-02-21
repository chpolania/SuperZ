using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZ.Startup))]
namespace SuperZ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
