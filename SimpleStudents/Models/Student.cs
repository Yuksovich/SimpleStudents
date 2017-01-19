using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class Student : Person
    {
        public Student()
        {
            base.Position = Role.Student;
        }
        public List<Course> VisitingCourses { get; set; }
        
    }
}