using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ITeacherCourseRepository : IRepository<TeacherCourse>
    {
    }
    public class TeacherCourseRepository : RepositoryBase<TeacherCourse>, ITeacherCourseRepository
    {
        public TeacherCourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
