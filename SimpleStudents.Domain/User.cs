﻿namespace SimpleStudents.Domain
{
    public abstract class User : EntityBase
    {
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