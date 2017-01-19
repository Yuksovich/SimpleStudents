using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private UniversityContext dbContext;

        public UniversityContext Init()
        {
            return dbContext ?? (dbContext = new UniversityContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}