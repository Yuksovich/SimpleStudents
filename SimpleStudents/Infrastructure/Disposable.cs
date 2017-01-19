using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleStudents.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDidposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDidposed && disposing)
            {
                DisposeCore();
            }
            isDidposed = true;
        }

        protected virtual void DisposeCore()
        {
            
        }
    }
}