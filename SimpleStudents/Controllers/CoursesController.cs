using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Data.Infrastructure;
using Data.Repositories;
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

        [HttpGet]
        public ActionResult ManageCourses()
        {
            var listCourseModel = Courses.GetAll().Select(s => new CourseModel
            {
                Id = s.Id,
                Name = s.Name,
                TeachersFullNames = s.TeacherCourse.Select(t=>t.Teacher.LastName+ " "+ t.Teacher.FirstName)
            }).ToList();
            return View(listCourseModel);
        }

        public ActionResult NewCourse()
        {
           var addNewCourse = new AddNewCourseModel
           {
                ChooseTeachers  = Teachers.GetAll().Select(s=>new AddNewCourseTeacher
                {
                    Id = s.Id,
                    FullName = s.LastName + " " + s.FirstName
                }).ToList()
           };
            return View(addNewCourse);
        }

        public ActionResult AddCourse(AddNewCourseModel model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("ManageCourses");
            }
            return View("NewCourse", model);
        }
    }
}