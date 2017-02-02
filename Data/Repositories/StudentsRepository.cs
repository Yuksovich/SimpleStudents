using SimpleStudents.Data.Infrastructure;
using SimpleStudents.Domain;

namespace SimpleStudents.Data.Repositories
{
    public interface IStudentsRepository : IRepository<Student>
    {
    }

    public class StudentsRepository : RepositoryBase<Student>, IStudentsRepository
    {
        public StudentsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}