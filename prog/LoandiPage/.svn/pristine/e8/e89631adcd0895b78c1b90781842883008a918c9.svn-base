using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomerCallBack.Startup))]
namespace CustomerCallBack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
