using System;
using Data.Repositories;

namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        ITeacherRepository Teachers { get; }
        IStudentsRepository Students { get; }
        void Commit();
    }
}
