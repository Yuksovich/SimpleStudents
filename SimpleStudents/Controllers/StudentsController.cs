using System.Web.Mvc;
using Data.Infrastructure;
using SimpleStudents.Web.Models;

namespace SimpleStudents.Web.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var context = new UniversityContext();
                context.Students.Add(new Domain.Student()
                {
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName
                });
                context.SaveChanges();
                return Content("Yes");
            }
            return Content("no");
        }
    }
}