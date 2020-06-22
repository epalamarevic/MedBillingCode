using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalBilling.WebMVC.Startup))]
namespace MedicalBilling.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
