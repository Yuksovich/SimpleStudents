using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleStudents.Web.Models.Students
{
    public class StudentModel:UserModel
    {
        [Required, MaxLength(255), Display(Name = "E-mail"), RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Display(Name = "Avarage mark")]
        public double? AvarageMark { get; set; }
    }
}