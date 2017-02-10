using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;
using SimpleStudents.Web.Models.Teachers;

namespace SimpleStudents.Web.Api
{
    public class TeachersController : ApiController
    {
        private ITeacherRepository Teachers { get; }
        private ITeacherCourseRepository TeacherCourse { get; }
        private IUnitOfWork UnitOfWork { get; }

        public TeachersController(ITeacherRepository teacherRepository, ITeacherCourseRepository teacherCourse, IUnitOfWork unitOfWork)
        {
            Teachers = teacherRepository;
            TeacherCourse = teacherCourse;
            UnitOfWork = unitOfWork;
        }
        // GET: api/Teachers
        [HttpGet]
        public IEnumerable<TeacherModel> Get()
        {
            return Teachers.GetAll().Select(s => new TeacherModel()
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                CoursesNames = s.TeacherCourses.Select(n=>n.Course.Name),
                CourseIds = s.TeacherCourses.Select(ci=>ci.CourseId)
            });
        }

        // GET: api/Teachers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Teachers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Teachers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teachers/5
        [HttpDelete]
        [Route("api/teachers/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Teachers.Delete(i => i.Id == id);
            TeacherCourse.Delete(i => i.TeacherId == id);
            UnitOfWork.Commit();
            return Ok();
        }
    }
}
