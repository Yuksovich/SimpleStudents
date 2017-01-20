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
            var coursesList = new List<CourseModel>();
            var courses = _context.Courses.ToArray();
            foreach (var course in courses)
            {
                coursesList.Add(new CourseModel()
                {
                    Name = course.Name,
                    TeacherId = course.Teacher.Id,
                    TeacherFirsName = course.Teacher.FirstName,
                    TeacherLastName = course.Teacher.LastName
                });
            }
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