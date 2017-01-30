using System.Collections.Generic;

namespace SimpleStudents.Domain
{
    public class Student : User
    {
        public Student()
        {
            base.Position = Role.Student;
        }

        public string Email { get; set; }
        public IList<Description> Descriptions { get; set; }
    }
}