using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SimpleStudents.Domain;

namespace Data.Infrastructure
{
    public interface IRepository<T> where T : class, IEntity
   {
       void Add(T entity);
       void Update(T entity);
       void Delete(T entity);
       void Delete(Expression<Func<T, bool>> where);
       IEnumerable<T> GetAll();
       IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
   }
}
