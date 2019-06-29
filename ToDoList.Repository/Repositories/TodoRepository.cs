using System;
using System.Linq;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Entities;
using ToDoList.Repository.Context;

namespace ToDoList.Repository.Repositories
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {

        public TodoRepository(TodoContext todoContext)
            :base(todoContext)
        {
        }

        public IQueryable<Todo> GetByUser(int userId)
        {
            var query = GetAllItems()
                .Where(x => x.UserId == userId);

            return query;
        }

        public bool MarkAsDone(int todoId, bool done)
        {
            var doneResult = false;

            var todo = GetById(todoId);

            if (todo != null)
            {
                todo.Done = done;
                todo.ModificationDate = DateTime.Now;

                doneResult = Update(todo);
            }

            return doneResult;
        }

    }
}
