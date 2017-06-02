using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KillerAppSharingPlatform.Startup))]
namespace KillerAppSharingPlatform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
