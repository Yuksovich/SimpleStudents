using System.Web.Mvc;
using SimpleStudents.Web.Models;

namespace SimpleStudents.Web.Controllers
{
    public class CoursesController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            
            return View();
        }
    }
}