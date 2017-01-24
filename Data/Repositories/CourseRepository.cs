using Data.Infrastructure;
using SimpleStudents;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
