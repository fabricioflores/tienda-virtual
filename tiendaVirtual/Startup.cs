using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tiendaVirtual.Startup))]
namespace tiendaVirtual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
