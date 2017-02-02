using System.Data.Entity;

namespace SimpleStudents.Data.Infrastructure
{
    public class UniversitySeeder : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
        }
    }
}