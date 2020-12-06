using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.News.Startup))]
namespace App.News
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
