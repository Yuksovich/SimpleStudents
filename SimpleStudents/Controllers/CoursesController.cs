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
        public ActionResult Manage()
        {
            return View(getCoursesTable());
        }

        [HttpPost]
        public ActionResult Manage(CourseModel course)
        {
            
            return RedirectToAction("Manage");
        }

        private List<CourseModel> getCoursesTable()
        {
            var coursesModelList = new List<CourseModel>();
            var courses = Courses.GetAll();
            foreach (var course in courses)
            {
                var teacherModelsList = new List<TeacherModel>();
                var teachers = course.TeacherCourse.Select(c => c.Teacher);
                foreach (var teacher in teachers)
                    teacherModelsList.Add(new TeacherModel
                    {
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName
                    });

                coursesModelList.Add(new CourseModel
                {
                    Name = course.Name,
                    Teachers = teacherModelsList
                });
            }
            return coursesModelList;
        }
    }
}