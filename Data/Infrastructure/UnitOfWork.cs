using SimpleStudents;

namespace Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbFactory _dbFactory;
        private UniversityContext _dbContext;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public UniversityContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public void Commit()
        {

        }
    }
}
