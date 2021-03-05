using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Centric_Project_rc744716.Startup))]
namespace Centric_Project_rc744716
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
