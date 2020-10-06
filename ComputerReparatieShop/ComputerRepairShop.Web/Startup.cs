using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputerRepairShop.Web.Startup))]
namespace ComputerRepairShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
