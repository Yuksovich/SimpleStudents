using System.Collections.Generic;
using SimpleStudents.Web.Models.Courses;

namespace SimpleStudents.Web.Models.Teachers
{
    public class TeacherModel : UserModel
    {
        public IEnumerable<int> CourseIds { get; set; }
        public IEnumerable<string> CoursesNames { get; set; }
    }
}