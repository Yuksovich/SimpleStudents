using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleStudents.Models;

namespace SimpleStudents.Configuration
{
    public class TeacherConfiguration:EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            ToTable("Teachers");
            Property(g => g.FirstName).IsRequired().HasMaxLength(100);
            Property(g => g.LastName).IsRequired().HasMaxLength(100);
           // Property(g => g.TeachingCourse.Name).IsRequired();
        }
    }
}