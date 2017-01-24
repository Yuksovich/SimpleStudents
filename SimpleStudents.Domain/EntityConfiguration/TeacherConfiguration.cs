using System.Data.Entity.ModelConfiguration;

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
