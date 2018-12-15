using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyDec2018.Startup))]
namespace VidlyDec2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
