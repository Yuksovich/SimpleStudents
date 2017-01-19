using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class Course
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }

    public enum CourseNames
    {
        Math,
        Geometry,
        Physics,
        English,
        Russian
    }
}