using System.Data.Entity;
using Data.Infrastructure;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface IStudentsRepository : IRepository<Student>
    {
        
    }

    public class StudentsRepository : RepositoryBase<Student>, IStudentsRepository
    {
        public StudentsRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
