using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleStudents.Domain;

namespace SimpleStudents.Models
{
    public class StudentModel : UserModel
    {
        public IDictionary<Course, Description> CoursesAndDescriptions { get; set; }
    }
}