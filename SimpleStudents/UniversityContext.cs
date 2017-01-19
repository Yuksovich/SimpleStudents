using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleStudents.Configuration;
using SimpleStudents.Domain;
using SimpleStudents.Models;

namespace SimpleStudents
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDbContext")
        {
        }

        public DbSet<Student> Students { get; set; }
       // public DbSet<Teacher> Teachers { get; set; }
       // public DbSet<Course> Courses { get; set; }
    }
}