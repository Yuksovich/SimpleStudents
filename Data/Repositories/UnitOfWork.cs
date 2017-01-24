using Data.Infrastructure;
using SimpleStudents;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;
        public ICourseRepository Courses { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public IStudentsRepository Students { get; private set; }

        public UnitOfWork(UniversityContext context)
        {
            _context = context;
            Courses = new CourseRepository(context);
            Teachers = new TeacherRepository(context);
            Students = new StudentsRepository(context);
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
