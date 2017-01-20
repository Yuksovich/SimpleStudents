using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleStudents.Domain;

namespace SimpleStudents
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