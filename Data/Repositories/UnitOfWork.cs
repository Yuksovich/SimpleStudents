using System.Data.Entity;
using Data.Infrastructure;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public ICourseRepository Courses { get; set; }
        public ITeacherRepository Teachers { get; set; }
        public IStudentsRepository Students { get; set; }

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
