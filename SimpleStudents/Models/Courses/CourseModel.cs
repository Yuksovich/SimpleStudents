using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Models.Courses
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required, MaxLength(255), Display(Name = "Course Name")]
        public string Name { get; set; }
        public int TeacherId { get; set; }

        [Display(Name = "Teachers")]
        public IEnumerable<string> TeachersFullNames { get; set; }
    }
}