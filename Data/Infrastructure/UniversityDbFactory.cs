using System.Data.Entity;

namespace SimpleStudents.Data.Infrastructure
{
    public class UniversityDbFactory : Disposable, IDbFactory
    {
        private UniversityContext _dbContext;

        public DbContext Init()
        {
            return _dbContext ?? (_dbContext = new UniversityContext());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
