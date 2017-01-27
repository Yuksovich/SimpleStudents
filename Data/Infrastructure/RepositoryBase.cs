using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SimpleStudents.Domain;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> Set;

        protected RepositoryBase(IDbFactory dbFactory)
        {
            Context = dbFactory.Init();
            Set = Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            Set.Add(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var enumerable = Set.Where(where).AsEnumerable();
            foreach (var entity in enumerable)
                Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Set;
        }

        public virtual T Get(int id)
        {
            return Set.Find(id);
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return Set.Where(where);
        }

        public virtual void Update(T entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}