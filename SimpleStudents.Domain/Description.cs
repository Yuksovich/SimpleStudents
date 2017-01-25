namespace SimpleStudents.Domain
{
    public class Description : EntityBase
    {
        public int Mark { get; set; }
        public TeacherCourse TeacherCourse { get; set; }
        public Student Student { get; set; }
    }
}