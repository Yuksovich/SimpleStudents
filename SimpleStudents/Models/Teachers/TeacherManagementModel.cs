using System.Collections.Generic;
using SimpleStudents.Web.Models.Courses;

namespace SimpleStudents.Web.Models.Teachers
{
    public class TeacherManagementModel
    {
        public List<TeacherModel> Teachers { get; set; }
        public List<int> CoursesIds { get; set; }
        public List<CourseModel> Courses { get; set; }
    }
}