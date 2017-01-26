﻿using System.Collections.Generic;
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
            var teachers = Teachers.GetAll();
            var teacherModelList = new List<TeacherModel>();
            foreach (var teacher in teachers)
            {
                var teacherModel = new TeacherModel()
                {
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Courses = new List<CourseModel>()
                };
                foreach (var teacherCourse in teacher.TeacherCourses)
                {
                    teacherModel.Courses.Add(new CourseModel()
                    {
                        Name = teacherCourse.Course.Name,
                    });
                }
                teacherModelList.Add(teacherModel);
            }
            return View(teacherModelList);
        }

        [HttpPost]
        public ActionResult Manage(TeacherModel teacherModel)
        {
            //var teacher = new Teacher()
            //{
            //    FirstName = teacherModel.FirstName,
            //    LastName = teacherModel.LastName,
            //};
            //Teachers.Add(teacher);

            //foreach (var courseId in teacherModel.CourseIds)
            //{
            //    var course = Courses.Get(courseId);
            //    course = teacher;
            //    Courses.Update(course);
            //}
            //UnitOfWork.Commit();
            
            return RedirectToAction("Manage");
        }
    }
}