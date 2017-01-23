using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Domain
{
    public class Student : User
    {
        public Student()
        {
            base.Position = Role.Student;
        }

        public IList<Description> Descriptions { get; set; }
    }
}