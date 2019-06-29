using System;
using System.Linq;
using System.Linq.Expressions;

namespace ToDoList.Domain.Contracts.Repository
{
    public interface IBaseRepository <T> : IDisposable where T : class
    {
        T GetById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        IQueryable<T> GetAllItems(params Expression<Func<T, object>>[] includes);

    }
}
