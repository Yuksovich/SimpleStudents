using System;
using System.Data.Entity;

namespace SimpleStudents.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DbContext Init();
    }
}
