using System;
using System.Linq;
using System.Linq.Expressions;
using SimpleStudents.Domain;

namespace SimpleStudents.Data.Infrastructure
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
