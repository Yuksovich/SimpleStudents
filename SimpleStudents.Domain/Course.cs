using System.Collections.Generic;

namespace SimpleStudents.Domain
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public IList<TeacherCourse> TeacherCourse { get; set; }
    }
}