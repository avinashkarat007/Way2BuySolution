using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Way2Buy.Startup))]
namespace Way2Buy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
