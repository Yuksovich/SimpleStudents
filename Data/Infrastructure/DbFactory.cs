using SimpleStudents;

namespace Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private UniversityContext _dbContext;

        public UniversityContext Init()
        {
            return _dbContext ?? (_dbContext = new UniversityContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
