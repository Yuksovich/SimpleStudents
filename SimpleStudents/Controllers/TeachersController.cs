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
    public class TeachersController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherCourseRepository TeacherCourse { get; set; }
        public ITeacherRepository Teachers { get; set; }

        [HttpGet]
        public ActionResult ManageTeachers()
        {
            var teachers = Teachers.GetAll().Select(s => new TeacherModel
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                CoursesNames = s.TeacherCourses.Select(c => c.Course.Name)
            }).ToList();
            return View(teachers);
        }

        public ActionResult NewTeacher()
        {
            var addNewteacherModel = new AddNewTeacherModel
            {
                SimplifiedCourseModels = Courses.GetAll().Select(s => new SimplifiedCourseModel
                {
                    Id = s.Id,
                    CourseName = s.Name
                }).ToList()
            };
            return View(addNewteacherModel);
        }

        [HttpPost]
        public ActionResult AddTeacher(AddNewTeacherModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("NewTeacher", model);
            }

            var teacher = new Teacher
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            Teachers.Add(teacher);
            UnitOfWork.Commit();

            var coursesSelected = model.SimplifiedCourseModels.Where(s => s.IsSelected).Select(s => s.Id);
            foreach (var courseId in coursesSelected)
            {
                TeacherCourse.Add( new TeacherCourse
                {
                    TeacherId = teacher.Id,
                    CourseId = courseId
                });
            }
            UnitOfWork.Commit();

            return RedirectToAction("ManageTeachers");
        }
    }
}