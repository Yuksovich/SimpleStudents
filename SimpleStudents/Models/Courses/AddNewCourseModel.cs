using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStudents.Web.Models.Courses
{
    public class AddNewCourseModel
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string CourseName { get; set; }
        
        public List<AddNewCourseTeacher> ChooseTeachers { get; set; }
    }

    public class AddNewCourseTeacher
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public bool Choosen { get; set; }
    }
}