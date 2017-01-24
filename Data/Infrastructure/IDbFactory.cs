using System;
using System.Data.Entity;

namespace Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DbContext Init();
    }
}
