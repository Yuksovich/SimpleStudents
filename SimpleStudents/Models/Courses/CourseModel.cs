using System.ComponentModel.DataAnnotations;

namespace SimpleStudents.Web.Models.Courses
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherFirsName { get; set; }
        public string TeacherLastName { get; set; }
    }
}