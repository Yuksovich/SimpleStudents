using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SimpleStudents.Domain;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext Context;

        protected RepositoryBase(IDbFactory dbFactory)
        {
            Context = dbFactory.Init();
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var enumerable = Context.Set<T>().Where(where).AsEnumerable();
            foreach (var entity in enumerable)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().Where(where).AsEnumerable();
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
