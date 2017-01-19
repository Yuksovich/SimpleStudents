using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        UniversityContext Init();
    }
}