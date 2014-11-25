using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsExam.Startup))]
namespace NewsExam
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
