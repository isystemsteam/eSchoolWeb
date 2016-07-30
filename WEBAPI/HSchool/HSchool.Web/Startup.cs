using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HSchool.Web.Startup))]
namespace HSchool.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
