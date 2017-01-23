using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SimpleStudents;
using SimpleStudents.Domain;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext context;

        protected RepositoryBase(DbContext dbContext)
        {
            context = dbContext;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var enumerable = context.Set<T>().Where(where).AsEnumerable();
            foreach (var entity in enumerable)
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().Where(where).AsEnumerable();
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
