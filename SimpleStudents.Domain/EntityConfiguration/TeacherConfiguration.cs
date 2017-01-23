using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudents.Domain.EntityConfiguration
{
    public class TeacherConfiguration: EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(255); 
        }
    }
}
