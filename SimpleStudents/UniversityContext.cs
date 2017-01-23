﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using SimpleStudents.Domain;
using SimpleStudents.Domain.EntityConfiguration;

namespace SimpleStudents
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDbContext")
        {
            Database.SetInitializer(new UniversitySeeder());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Description> Descriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}

