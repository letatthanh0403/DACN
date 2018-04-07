using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Day1.Startup))]
namespace Day1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
