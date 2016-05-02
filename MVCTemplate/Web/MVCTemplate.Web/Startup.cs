using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTemplate.Web.Startup))]
namespace MVCTemplate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
