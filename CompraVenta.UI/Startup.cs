using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompraVenta.UI.Startup))]
namespace CompraVenta.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
