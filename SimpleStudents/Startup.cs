using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using Microsoft.Owin;
using Owin;
using SimpleStudents.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace SimpleStudents.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<UniversityDbFactory>().As<IDbFactory>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
