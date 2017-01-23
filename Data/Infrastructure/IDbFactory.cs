using System;
using SimpleStudents;

namespace Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        UniversityContext Init();
    }
}
