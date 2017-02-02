using System.Data.Entity;
using System.Diagnostics;
using SimpleStudents.Domain;
using SimpleStudents.Domain.EntityConfiguration;

namespace SimpleStudents.Data.Infrastructure
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDbContext")
        {
            Database.SetInitializer(new UniversitySeeder());
            //TODO remove log
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}