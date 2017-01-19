﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class Student : User
    {
        public Student()
        {
            base.Position = Role.Student;
        }
        public IEnumerable<Course> StudyingCources { get; set; }
       
    }
}