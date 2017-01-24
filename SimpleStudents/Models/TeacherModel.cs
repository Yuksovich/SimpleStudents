using System.Collections.Generic;

namespace SimpleStudents.Web.Models
{
    public class TeacherModel : UserModel
    {
        public IList<int> CourseId { get; set; }
        public IList<CourseModel> Courses { get; set; }
    }
}