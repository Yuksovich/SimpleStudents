using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using SimpleStudents.Web.Models.Courses;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Controllers
{
    public class TeachersController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherRepository Teachers { get; set; }

        [HttpGet]
        public ActionResult Manage()
        {
            return View(GetTeachersTable());
        }

        [HttpPost]
        public ActionResult Manage(TeacherModel teacherModel)
        {
            
            return RedirectToAction("Manage");
        }

        private List<TeacherModel> GetTeachersTable()
        {
            var teacherModelList = Teachers.GetAll().Select(t => new TeacherModel()
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                Courses = t.TeacherCourses.Select(tc => new CourseModel() {Name = tc.Course.Name})
            }).ToList();
            
            return teacherModelList;
        }
    }
}