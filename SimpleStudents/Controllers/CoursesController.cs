using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using SimpleStudents.Web.Models.Courses;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Controllers
{
    public class CoursesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherRepository Teachers { get; set; }

        [HttpGet]
        public ActionResult Manage()
        {
            return View(GetCoursesTable());
        }

        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            return RedirectToAction("Manage");
        }

        private List<CourseModel> GetCoursesTable()
        {
            // var listCourseModel = new List<CourseModel>();

            var listCourseModel =
                Courses.GetAll()
                    .Select(s =>new CourseModel{
                                Name = s.Name,
                                Teachers =s.TeacherCourse.Select(tc =>new TeacherModel{
                                                FirstName = tc.Teacher.FirstName,
                                                LastName = tc.Teacher.LastName
                                            })
                            }).ToList();

            return listCourseModel;
        }
    }
}