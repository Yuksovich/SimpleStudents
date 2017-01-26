namespace SimpleStudents.Domain
{
    public class TeacherCourse : EntityBase
    {
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
    }
}
