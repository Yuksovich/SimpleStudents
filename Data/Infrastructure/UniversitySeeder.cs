using System.Collections.Generic;
using System.Data.Entity;
using SimpleStudents.Domain;

namespace Data.Infrastructure
{
    public class UniversitySeeder : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            List<Course> coursesList = new List<Course>()
            {
                new Course() {Name = "Physics"},
                new Course() {Name = "Math" },
                new Course() {Name = "English" }
            };
            foreach (var course in coursesList)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();
                base.Seed(context);
        }
    }
}