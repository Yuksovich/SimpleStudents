using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using SimpleStudents.Domain;
using SimpleStudents.Web.Models;

namespace SimpleStudents.Web.Controllers
{
    public class CoursesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        
        [HttpGet]
        public ActionResult Manage()
        {
            IEnumerable<Course> listOfCourses = Courses.GetAll();
            
            return View(listOfCourses);
        }
        
        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            Courses.Add(new Course() {Name = course.Name});
            UnitOfWork.Commit();
            IEnumerable<Course> listOfCourses = Courses.GetAll();
            return View(listOfCourses);
        }
    }
}