using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStudents.Web.Models.Students
{
    public class StudentModel:UserModel
    {
        [Required, MaxLength(255), Display(Name = "E-mail"), EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Avarage mark")]
        public double? AvarageMark { get; set; }
    }
}