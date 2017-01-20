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

        public List<Description> Descriptions { get; set; }
    }
}