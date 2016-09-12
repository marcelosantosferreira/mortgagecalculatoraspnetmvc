using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MortgageCalculator.WebUI.Startup))]
namespace MortgageCalculator.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
