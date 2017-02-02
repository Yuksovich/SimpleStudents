using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Domain;

namespace SimpleStudents.Data.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}