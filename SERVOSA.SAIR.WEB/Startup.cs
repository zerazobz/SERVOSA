using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SERVOSA.SAIR.WEB.Startup))]
namespace SERVOSA.SAIR.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
