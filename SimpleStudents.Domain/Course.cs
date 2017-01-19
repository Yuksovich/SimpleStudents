using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Domain
{
    public class Course:EntityBase
    {

        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Course> TeachingCourses { get; set; }
    }
}