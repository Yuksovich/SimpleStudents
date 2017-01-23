using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Domain
{
    public class Teacher : User
    {
        public Teacher()
        {
            base.Position = Role.Teacher;
        }
        public IList<Course> TeachingCourses { get; set; }
    }
}