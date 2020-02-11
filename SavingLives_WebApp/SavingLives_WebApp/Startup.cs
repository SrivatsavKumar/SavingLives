using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SavingLives_WebApp.Startup))]
namespace SavingLives_WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
