using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_2.Startup))]
namespace mvc_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
