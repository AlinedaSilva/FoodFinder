using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodFinder.Startup))]
namespace FoodFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
