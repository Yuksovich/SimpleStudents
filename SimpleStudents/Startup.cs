using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Web;
using SimpleStuedents.Services;

[assembly: OwinStartup(typeof(Startup))]

namespace SimpleStudents.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var config = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<UniversityDbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerRequest(); ;
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().InstancePerRequest(); ;
            builder.RegisterType<StudentsRepository>().As<IStudentsRepository>().InstancePerRequest();
            builder.RegisterType<TeacherCourseRepository>().As<ITeacherCourseRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            
            builder.RegisterType<TeacherCourseServices>().As<ITeachersCourseServices>().InstancePerRequest();
           
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}