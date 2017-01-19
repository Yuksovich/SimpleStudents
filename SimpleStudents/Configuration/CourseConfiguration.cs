using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleStudents.Models;

namespace SimpleStudents.Configuration
{
    public class CourseConfiguration:EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Courses");
            Property(g => g.Name).IsRequired().HasMaxLength(100);
            Property(g => g.Teacher.FirstName).IsRequired();
            Property(g => g.Teacher.LastName).IsRequired();
        }
    }
}