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
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<UniversityDbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerRequest(); ;
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerRequest(); ;
            builder.RegisterType<StudentsRepository>().As<IStudentsRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest(); ;

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}