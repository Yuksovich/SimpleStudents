using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Models.Courses
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<int> TeachersIds { get; set; }
        public IEnumerable<TeacherModel> Teachers { get; set; }
    }
}