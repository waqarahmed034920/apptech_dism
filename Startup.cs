using Microsoft.Owin;
using Owin;
using SurveyPortal.App_Start;

[assembly: OwinStartupAttribute(typeof(SurveyPortal.Startup))]
namespace SurveyPortal
{
    public partial class Startup
    { 
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // IdentityDataInitializer.InitializeData();
        }
    }
}