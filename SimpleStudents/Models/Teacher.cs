using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class Teacher:Person
    {
        public Teacher()
        {
            base.Position = Role.Teacher;
        }
        public Course TeachingCourse { get; set; }
    }
}