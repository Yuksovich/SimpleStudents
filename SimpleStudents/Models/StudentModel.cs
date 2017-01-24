using System.Collections.Generic;
using SimpleStudents.Domain;

namespace SimpleStudents.Web.Models
{
    public class StudentModel : UserModel
    {
        public IDictionary<Course, Description> CoursesAndDescriptions { get; set; }
    }
}