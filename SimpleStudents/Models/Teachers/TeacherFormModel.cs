using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStudents.Web.Models.Teachers
{
    public class TeacherFormModel
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength(255)]
        public string LastName { get; set; }
        public List<SimplifiedCourseModel> SimplifiedCourseModels { get; set; }
    }

    public class SimplifiedCourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public bool IsSelected { get; set; }
    }
}