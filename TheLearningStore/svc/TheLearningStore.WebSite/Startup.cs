using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheLearningCenter.WebSite.Startup))]
namespace TheLearningCenter.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
