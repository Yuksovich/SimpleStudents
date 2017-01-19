using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Domain
{
     public abstract class User:EntityBase
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Position { get; set; }
        
    }

    public enum Role
    {
        Student = 1,
        Teacher = 2,
        Dean = 3
    }
}