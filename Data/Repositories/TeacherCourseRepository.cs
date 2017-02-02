using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Domain;

namespace SimpleStudents.Data.Repositories
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
