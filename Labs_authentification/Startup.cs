using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Labs_authentification.Startup))]
namespace Labs_authentification
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
