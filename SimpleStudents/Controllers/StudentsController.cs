using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Domain;
using SimpleStudents.Web.Models.Courses;
using SimpleStudents.Web.Models.Students;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly List<CourseModel> _courseModelsList = new List<CourseModel>();
        public IStudentsRepository Students { get; set; }
        public ICourseRepository Courses { get; set; }
        public ITeacherRepository Teachers { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        [HttpGet]
        public ActionResult ManageStudents()
        {
            var students = Students.GetAll().Select(s => new StudentModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                AvarageMark = s.Descriptions.Average(a => a.Mark)
            }).ToList();
            return View(students);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return View("NewStudent", studentModel);
            }

            if (!Students.GetAll().Any(s => s.Email == studentModel.Email))
            {
                Students.Add(new Student()
                {
                    FirstName = studentModel.FirstName,
                    LastName = studentModel.LastName,
                    Email = studentModel.Email
                });
                UnitOfWork.Commit();
                return RedirectToAction("ManageStudents");
            }

            ModelState.AddModelError("Error", "User already exists");

            return View("NewStudent", studentModel);
        }

        [HttpGet]
        public ActionResult NewStudent()
        {
            return View();
        }
    }
}