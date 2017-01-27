using System.Collections.Generic;
using System.Linq;
using Data.Infrastructure;
using SimpleStudents;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface IStudentsRepository : IRepository<Student>
    {
    }

    public class StudentsRepository : RepositoryBase<Student>, IStudentsRepository
    {
        public StudentsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Student> GetAllStudentsPaging(int pageIndex, int pageSize = 10)
        {
            return
                Set.OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize);
        }
    }
}
