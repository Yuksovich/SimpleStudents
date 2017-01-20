using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class CourseModel
    {
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherFirsName { get; set; }
        public string TeacherLastName { get; set; }
    }
}