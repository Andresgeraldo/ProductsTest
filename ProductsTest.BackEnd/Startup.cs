using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductsTest.BackEnd.Startup))]
namespace ProductsTest.BackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
