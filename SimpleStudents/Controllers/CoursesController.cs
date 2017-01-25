using System.Collections.Generic;
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
            var managementModel = new CourseManagementModel
            {
                Courses = new List<CourseModel>(),
                Teachers = new List<TeacherModel>()
            };

            foreach (var course in Courses.GetAll())
            {
                managementModel.Courses.Add(new CourseModel()
                {
                    Name = course.Name,
                    TeacherId = course.Teacher?.Id,
                    TeacherFirsName = course.Teacher?.FirstName,
                    TeacherLastName = course.Teacher?.LastName
                });
            }
            
            foreach (var teacher in Teachers.GetAll())
            {
                managementModel.Teachers.Add(new TeacherModel()
                {
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Id = teacher.Id
                });
            }

            return View(managementModel);
        }

        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            if (ModelState.IsValid)
            {
                Courses.Add(new Course {Name = course.Name});
                UnitOfWork.Commit();
            }
            return RedirectToAction("Manage");
        }
    }
}