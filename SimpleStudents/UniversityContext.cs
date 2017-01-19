using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleStudents.Configuration;
using SimpleStudents.Models;

namespace SimpleStudents
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("University Entities")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}