using System.Data.Entity;
using System.Linq;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override IQueryable<Course> GetAll()
        {
            return Set
                .Include(i => i.TeacherCourse)
                .Include(c => c.TeacherCourse.Select(s => s.Teacher));
        }
    }
}