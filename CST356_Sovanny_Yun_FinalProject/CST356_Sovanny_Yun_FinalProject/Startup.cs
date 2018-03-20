using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CST356_Sovanny_Yun_FinalProject.Startup))]
namespace CST356_Sovanny_Yun_FinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
