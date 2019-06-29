using System.Linq;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts.Repository
{
    public interface ITodoRepository : IBaseRepository<Todo>
    {

        IQueryable<Todo> GetByUser(int userId);
        bool MarkAsDone(int todoId, bool done);

    }
}
