using System.Data.Entity.ModelConfiguration;

namespace SimpleStudents.Domain.EntityConfiguration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
