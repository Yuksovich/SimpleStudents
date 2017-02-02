using System.Collections.Generic;
using System.Data.Entity.Migrations;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Domain;

namespace SimpleStudents.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "UniversityContext";
        }

        protected override void Seed(UniversityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var teacher1 = new Teacher {FirstName = "Vasya", LastName = "Vasin"};
            var teacher2 = new Teacher {FirstName = "Ivan", LastName = "Ivanov"};
            var teacher3 = new Teacher {FirstName = "Petr", LastName = "Petrov"};
            var course1 = new Course {Name = "Java"};
            var course2 = new Course {Name = "C#"};
            var course3 = new Course {Name = "Visual Basic"};
            var teacherCourse11 = new TeacherCourse {Course = course1, Teacher = teacher1};
            var teacherCourse22 = new TeacherCourse {Course = course2, Teacher = teacher2};
            var teacherCourse33 = new TeacherCourse {Course = course3, Teacher = teacher3};
            var teacherCourse31 = new TeacherCourse {Course = course3, Teacher = teacher1};
            var teacherCourse23 = new TeacherCourse {Course = course2, Teacher = teacher3};

            course1.TeacherCourse = new List<TeacherCourse>
            {
                teacherCourse11
            };
            course2.TeacherCourse = new List<TeacherCourse>
            {
                teacherCourse22,
                teacherCourse23
            };
            course3.TeacherCourse = new List<TeacherCourse>
            {
                teacherCourse31,
                teacherCourse33
            };

            teacher1.TeacherCourses = new List<TeacherCourse>
            {
                teacherCourse31,
                teacherCourse11
            };

            teacher2.TeacherCourses = new List<TeacherCourse>
            {
                teacherCourse22
            };

            teacher3.TeacherCourses = new List<TeacherCourse>
            {
                teacherCourse23,
                teacherCourse33
            };

            context.Teachers.Add(teacher1);
            context.Teachers.Add(teacher2);
            context.Teachers.Add(teacher3);
            context.Courses.Add(course1);
            context.Courses.Add(course2);
            context.Courses.Add(course3);
            context.TeacherCourses.Add(teacherCourse11);
            context.TeacherCourses.Add(teacherCourse22);
            context.TeacherCourses.Add(teacherCourse33);
            context.TeacherCourses.Add(teacherCourse31);
            context.TeacherCourses.Add(teacherCourse23);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}