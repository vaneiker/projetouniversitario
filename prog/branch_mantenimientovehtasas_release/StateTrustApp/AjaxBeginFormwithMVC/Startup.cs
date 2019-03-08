using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxBeginFormwithMVC.Startup))]
namespace AjaxBeginFormwithMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
