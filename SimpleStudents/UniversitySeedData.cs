using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleStudents.Models;

namespace SimpleStudents
{
    public class UniversitySeedData:DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            GetStudents().ForEach(c=>context.Students.Add(c));
            GetTeachers().ForEach(c=>context.Teachers.Add(c));
            GetCourses().ForEach(c=>context.Courses.Add(c));

            context.Commit();
        }

        private static List<Student> GetStudents()
        {
            var list = new List<Student>()
            {
                new Student() {FirstName = "Vasya", LastName = "Ivanov"},
                new Student() {FirstName = "Ivan", LastName = "Vasiliev"}
            };
            return list;
        }

        private static List<Teacher> GetTeachers()
        {
            var list = new List<Teacher>()
            {
                new Teacher() {FirstName = "Uchitel", LastName = "Uchitilievich", TeachingCourse = new Course() {Name = "Math"} },
                new Teacher() {FirstName = "Propod", LastName = "Prepodovich", TeachingCourse = new Course() {Name = "English"} }
            };
            return list;
        }

        private static List<Course> GetCourses()
        {
            var teachers = GetTeachers();
            var courses  = new List<Course>();
            foreach (var teacher in teachers)
            {
                courses.Add(teacher.TeachingCourse);
            }
            return courses;
        }
    }
}