using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Repository.Context;

namespace ToDoList.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private TodoContext context;
        private bool disposed = false;

        public BaseRepository(TodoContext _context)
        {
            context = _context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (!Equals(context, null))
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }




        public virtual bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return SaveContext();
        }       

        public virtual IQueryable<T> GetAllItems(params Expression<Func<T, object>>[] includes)
        {
            var query = context.Set<T>().AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual bool Insert(T entity)
        {
            context.Set<T>().Add(entity);
            return SaveContext();
        }

        public virtual bool Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return SaveContext();
        }

        private bool SaveContext()
        {      
            return context.SaveChanges() > 0;            
        }


    }
}
