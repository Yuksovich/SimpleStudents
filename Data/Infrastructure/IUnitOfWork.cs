using System;

namespace SimpleStudents.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
