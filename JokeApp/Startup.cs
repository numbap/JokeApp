using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JokeApp.Startup))]
namespace JokeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
