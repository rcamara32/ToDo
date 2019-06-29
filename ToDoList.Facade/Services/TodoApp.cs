using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Entities;
using ToDoList.Facade.Contracts;
using ToDoList.Facade.Dto.Todo;

namespace ToDoList.Facade.Services
{
    public class TodoApp : ITodoApp
    {

        private readonly ITodoService todoService;
        

        public TodoApp(ITodoService _todoService)
        {
            todoService = _todoService;
        }

        public IList<TodoListDto> GetAllTodoListByUser(int userId)
        {

            return todoService.GetByUser(userId)                
                .Select(x => new TodoListDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Done = x.Done,
                    ModificationDate = x.ModificationDate
                }).ToList();
        }

        public TodoListDto GetById(int id)
        {
            var toDo =  todoService.GetById(id);

            if (toDo != null)
            {
                return new TodoListDto
                {
                    Id = toDo.Id,
                    Description = toDo.Description,
                    Done = toDo.Done,
                    ModificationDate = toDo.ModificationDate
                };
            }

            return null;
        }

        public bool Add(AddTodoDto addTodoDto, int userId)
        {
            var todo = new Todo()
            {
                Description = addTodoDto.Description,
                UserId = userId,
                ModificationDate = DateTime.Now,
                Done = false
            };

            return todoService.Add(todo);
        }

        public  bool Edit(NewTodoDto newTodoDto)
        {
            return todoService.Edit(newTodoDto.Id, newTodoDto.NewDescription);
        }

        public bool Delete(int id)
        {
            return todoService.Delete(id);
        }

        public bool Done(DoneTodoDto doneTodoDto)
        {
            return todoService.Done(doneTodoDto.Id, doneTodoDto.Done);
        }
    }
}
