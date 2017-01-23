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
        private UniversityContext _universityContext;
        private readonly DbSet<T> _dbSet;

        protected DbFactory DbFactory { get; private set; }

        protected UniversityContext DbContext => _universityContext ?? (_universityContext = DbFactory.Init());

        protected RepositoryBase(DbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var enumerable = _dbSet.Where(where).AsEnumerable();
            foreach (var entity in enumerable)
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _universityContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
