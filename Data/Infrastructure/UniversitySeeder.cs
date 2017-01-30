using System.Data.Entity;

namespace Data.Infrastructure
{
    public class UniversitySeeder : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
        }
    }
}