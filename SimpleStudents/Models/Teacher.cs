﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Models
{
    public class Teacher:User
    {
        public Teacher()
        {
            base.Position = Role.Teacher;
        }
        public IEnumerable<Course> TeachingCourse { get; set; }
    }
}