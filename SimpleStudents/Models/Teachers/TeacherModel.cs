using System.Collections.Generic;
using SimpleStudents.Web.Models.Courses;

namespace SimpleStudents.Web.Models.Teachers
{
    public class TeacherModel : UserModel
    {
        public IList<int> CourseIds { get; set; }
        public IList<CourseModel> Courses { get; set; }
    }
}