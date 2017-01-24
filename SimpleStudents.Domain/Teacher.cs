using System.Collections.Generic;

namespace SimpleStudents.Domain
{
    public class Teacher : User
    {
        public Teacher()
        {
            base.Position = Role.Teacher;
        }

        public IList<Course> TeachingCourses { get; set; }
    }
}