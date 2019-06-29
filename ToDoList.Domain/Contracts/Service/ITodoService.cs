using System.Linq;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts.Service
{
    public interface ITodoService
    {
        IQueryable<Todo> GetByUser(int userId);
        bool Add(Todo todo);
        Todo GetById(int id);
        bool Edit(int id, string description);
        bool Delete(int id);
        bool Done(int id, bool done);
    }
}
