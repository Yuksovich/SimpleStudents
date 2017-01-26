using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using SimpleStudents.Domain;
using SimpleStudents.Web.Models;
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
            var courses = Courses.GetAll();
            var courseModelList = new List<CourseModel>();
            foreach (var course in courses)
            {
                var courseModel = new CourseModel()
                {
                    Name = course.Name,
                    Teachers = new List<TeacherModel>()
                };
                foreach (var teacherCourse in course.TeacherCourse)
                {
                    courseModel.Teachers.Add(new TeacherModel()
                    {
                        FirstName = teacherCourse.Teacher.FirstName,
                        LastName = teacherCourse.Teacher.LastName
                    });
                }
                courseModelList.Add(courseModel);
            }

            return View(courseModelList);
        }

        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                Courses.Add(new Course { Name = course.Name });
                UnitOfWork.Commit();
            }
            return RedirectToAction("Manage");
        }
    }
}