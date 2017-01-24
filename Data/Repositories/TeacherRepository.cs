using Data.Infrastructure;
using SimpleStudents;
using SimpleStudents.Domain;

namespace Data.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniversityContext dbContext) : base(dbContext) { }
    }
}
