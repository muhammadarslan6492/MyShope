using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShope.WedUI.Startup))]
namespace MyShope.WedUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
