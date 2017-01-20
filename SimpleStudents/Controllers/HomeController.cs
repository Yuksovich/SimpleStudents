﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleStudents.Domain;
using SimpleStudents.Models;

namespace SimpleStudents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new UniversityContext())
            {

                //var student = new StudentModel() {FirstName = "John", LastName = "Doe"};
                //context.Students.Add(student);
                //context.SaveChanges();
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}