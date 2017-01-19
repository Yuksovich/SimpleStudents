using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleStudents.Startup))]
namespace SimpleStudents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
