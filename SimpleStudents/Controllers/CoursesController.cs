using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Domain;
using SimpleStudents.Web.Models.Courses;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Controllers
{
    public class CoursesController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherRepository Teachers { get; set; }
        public ITeacherCourseRepository TeacherCourse { get; set; }

        [HttpGet]
        public ActionResult ManageCourses()
        {
            var listCourseModel = Courses.GetAll().Select(s => new CourseModel
            {
                Id = s.Id,
                Name = s.Name,
                TeachersFullNames = s.TeacherCourse.Select(t => t.Teacher.LastName + " " + t.Teacher.FirstName)
            }).ToList();
            return View(listCourseModel);
        }

        public ActionResult NewCourse()
        {
            var addNewCourse = new AddNewCourseModel
            {
                ChooseTeachers = Teachers.GetAll().Select(s => new AddNewCourseTeacher
                {
                    Id = s.Id,
                    FullName = s.LastName + " " + s.FirstName
                }).ToList()
            };
            return View(addNewCourse);
        }

        public ActionResult AddCourse(AddNewCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCourse", model);
            }

            var course = new Course()
            {
                Name = model.CourseName
            };
            Courses.Add(course);
            UnitOfWork.Commit();

            var teachersIdsSelected = model.ChooseTeachers.Where(w => w.Choosen).Select(s => s.Id);
            foreach (var teacherId in teachersIdsSelected)
            {
                TeacherCourse.Add(new TeacherCourse
                {
                    CourseId = course.Id,
                    TeacherId = teacherId
                });
            }
            UnitOfWork.Commit();

            return RedirectToAction("ManageCourses");
        }
    }
}