using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Domain;
using SimpleStudents.Web.Models.Courses;
using SimpleStudents.Web.Models.Teachers;
using SimpleStuedents.Services;

namespace SimpleStudents.Web.Controllers
{
    public class TeachersController : Controller
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherCourseRepository TeacherCourse { get; set; }
        public ITeacherRepository Teachers { get; set; }
        public ITeachersCourseServices TeachersCourseServices { get; set; }

        [HttpGet]
        public ActionResult ManageTeachers()
        {
            var teachers = Teachers.GetAll().Select(s => new TeacherModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                CoursesNames = s.TeacherCourses.Select(c => c.Course.Name)
            }).ToList();
            return View(teachers);
        }

        [HttpGet]
        public ActionResult FormTeacher()
        {
            var addNewteacherModel = new TeacherFormModel
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
        public ActionResult AddTeacher(TeacherFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View("FormTeacher", formModel);
            }
            var teacher = new Teacher
            {
                Id = formModel.Id,
                FirstName = formModel.FirstName,
                LastName = formModel.LastName
            };

            if (formModel.Id == 0)
            {
                Teachers.Add(teacher);
                UnitOfWork.Commit();
            }
            else
            {
                Teachers.Update(teacher);
            }
            var coursesSelected = formModel.SimplifiedCourseModels.Where(s => s.IsSelected).Select(s => s.Id);
            TeachersCourseServices.Update(teacher.Id, coursesSelected);
            UnitOfWork.Commit();

            return RedirectToAction("ManageTeachers");
        }

        [HttpGet]
        public ActionResult EditTeacher(int id)
        {
            var teacher = Teachers.Get(id);
            var selectedCourses = TeacherCourse.GetAll().Where(s => s.TeacherId == id).Select(i => i.CourseId);
            var teacherFormModel = new TeacherFormModel
            {
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Id = id,
                SimplifiedCourseModels = Courses.GetAll().Select(s => new SimplifiedCourseModel
                {
                    Id = s.Id,
                    CourseName = s.Name,
                    IsSelected = selectedCourses.Contains(s.Id)
                }).ToList()
            };
            return View("FormTeacher", teacherFormModel);
        }

        [HttpGet]
        public ActionResult DeleteTeacher(int id)
        {
            Teachers.Delete(i => i.Id == id);
            TeacherCourse.Delete(i => i.TeacherId == id);
            UnitOfWork.Commit();
            return RedirectToAction("ManageTeachers");
        }
    }
}