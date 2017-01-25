using System.Collections.Generic;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
using SimpleStudents.Domain;
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
            var managementModel = new TeacherManagementModel()
            {
                Courses = new List<CourseModel>(),
                Teachers = new List<TeacherModel>()
            };

            foreach (var course in Courses.GetAll())
            {
                managementModel.Courses.Add(new CourseModel()
                {
                    Name = course.Name,
                    Id = course.Id
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
        public ActionResult Manage(TeacherModel teacherModel)
        {
            var teacher = new Teacher()
            {
                FirstName = teacherModel.FirstName,
                LastName = teacherModel.LastName,
            };
            Teachers.Add(teacher);

            foreach (var courseId in teacherModel.CourseIds)
            {
                var course = Courses.Get(courseId);
                course.Teacher = teacher;
                Courses.Update(course);
            }
            UnitOfWork.Commit();
            
            return RedirectToAction("Manage");
        }
    }
}