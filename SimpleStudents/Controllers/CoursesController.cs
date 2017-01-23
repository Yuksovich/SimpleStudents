using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleStudents.Domain;
using SimpleStudents.Models;

namespace SimpleStudents.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UniversityContext _context= new UniversityContext() ;

        [HttpGet]
        public ActionResult Manage()
        {
            var courses = _context.Courses.ToArray();
            var coursesList = courses.Select(c => new CourseModel()
            {
                Name = c.Name
            });
            return View(coursesList);
        }
        
        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            _context.Courses.Add(new Course() {Name = course.Name});
            _context.SaveChanges();
            ViewBag.Succes = course.Name;
            return View();
        }
    }
}