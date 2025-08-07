using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonoTest.Startup))]
namespace MonoTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
