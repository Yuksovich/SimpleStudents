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
        private readonly UniversityContext _context;

        public CourseRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            _context = Context as UniversityContext;
        }

        public override IQueryable<Course> GetAll()
        {
            return _context?.Courses
                .Include(i => i.TeacherCourse)
                .Include(c => c.TeacherCourse.Select(s => s.Teacher));
        }
    }
}