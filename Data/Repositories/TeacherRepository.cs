using System.Data.Entity;
using System.Linq;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override IQueryable<Teacher> GetAll()
        {
            return
                Set.Include(c => c.TeacherCourses).Include(i => i.TeacherCourses.Select(s => s.Course));
        }
    }
}