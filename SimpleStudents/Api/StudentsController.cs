using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Data.Repositories;

namespace SimpleStudents.Web.Api
{
    public class StudentsController : ApiController
    {
        private IStudentsRepository Students { get; }

        public StudentsController(IStudentsRepository students)
        {
            Students = students;
        }

        //GET api/students
        public IEnumerable<string> GetEmails()
        {
            return Students.GetAll().Select(s => s.Email).ToList();
        }
    }
}