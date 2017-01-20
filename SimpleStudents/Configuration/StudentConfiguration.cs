using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleStudents.Domain;

namespace SimpleStudents.Configuration
{
    public class StudentConfiguration:EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            ToTable("Students");
            Property(g => g.FirstName).IsRequired().HasMaxLength(100);
            Property(g => g.LastName).IsRequired().HasMaxLength(100);
            Property(g => g.Position).IsRequired();

        }
    }
}