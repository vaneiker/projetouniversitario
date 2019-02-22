using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehiculosyMarcas.Startup))]
namespace VehiculosyMarcas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
