using System.Data.Entity;
using SimpleStudents.Data.Infrastructure;

namespace SimpleStudents.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _context = dbFactory.Init();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
