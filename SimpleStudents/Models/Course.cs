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
        public IDictionary<Student, int> Students { get; set; }
    }
}