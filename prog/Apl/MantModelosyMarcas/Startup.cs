using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MantModelosyMarcas.Startup))]
namespace MantModelosyMarcas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
