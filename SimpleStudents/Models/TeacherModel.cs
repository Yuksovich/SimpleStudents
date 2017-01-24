using System.Collections.Generic;

namespace SimpleStudents.Models
{
    public class TeacherModel : UserModel
    {
        public IList<int> CourseId { get; set; }
        public IList<CourseModel> Courses { get; set; }
    }
}