using System.Data.Entity;
using SimpleStudents.Domain;
using SimpleStudents.Domain.EntityConfiguration;

namespace Data.Infrastructure
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDbContext")
        {
            Database.SetInitializer(new UniversitySeeder());
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
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

