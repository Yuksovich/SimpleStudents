using System.Data.Entity.ModelConfiguration;

namespace SimpleStudents.Domain.EntityConfiguration
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
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
