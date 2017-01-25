using System.Collections.Generic;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Models.Courses
{
    public class CourseManagementModel
    {
        public List<CourseModel> Courses { get; set; }
        public List<TeacherModel> Teachers { get; set; }
    }
}