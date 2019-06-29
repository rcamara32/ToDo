using System.Collections.Generic;
using ToDoList.Facade.Dto.Todo;

namespace ToDoList.Facade.Contracts
{
    public interface ITodoApp
    {

        IList<TodoListDto> GetAllTodoListByUser(int userId);
        TodoListDto GetById(int id);
        bool Add(AddTodoDto addTodoDto, int userId);
        bool Edit(NewTodoDto newTodoDto);
        bool Delete(int id);
        bool Done(DoneTodoDto doneTodoDto);
    }
}
