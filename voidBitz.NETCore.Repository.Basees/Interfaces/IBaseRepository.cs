using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace voidBitz.NETCore.Repository.Basees.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);

        IEnumerable<T> GetWhere(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true);

        T FirstOrDefault(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true);

        void Add(T entity);
        void Remove(T entity);

        bool Save();

        bool AddWithSave(T entity);

        bool RemoveWithSave(T entity);
        bool Exists(int Id);
        bool Exists(Expression<Func<T, bool>> predicate);

        bool DeleteById(int id);

        void Update(T entity);
        bool UpdateWithSave(T entity);
    }
}
