using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMart.Startup))]
namespace WebMart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
