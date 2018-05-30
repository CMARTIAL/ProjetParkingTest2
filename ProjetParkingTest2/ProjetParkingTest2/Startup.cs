using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetParkingTest2.Startup))]
namespace ProjetParkingTest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
