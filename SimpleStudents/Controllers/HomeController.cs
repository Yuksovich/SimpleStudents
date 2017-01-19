using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleStudents.Models;

namespace SimpleStudents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new UniversityContext())
            {

                var student = new Student() {FirstName = "John", LastName = "Doe", PersonId = 123};
                context.Students.Add(student);
                context.SaveChanges();
                return Content("Yes");
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