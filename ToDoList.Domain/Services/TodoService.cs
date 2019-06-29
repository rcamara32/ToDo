using System;
using System.Linq;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Services
{
    public class TodoService : ITodoService
    {

        private readonly ITodoRepository todoRepository;

        public TodoService(ITodoRepository _todoRepository)
        {
            todoRepository = _todoRepository;
        }

        public bool Add(Todo todo)
        {
            var added = false;

            if (!string.IsNullOrEmpty(todo.Description) && todo.UserId > 0)
            {
                added = todoRepository.Insert(todo);
            }

            return added;
        }

        public bool Delete(int id)
        {
            var deleted = false;

            var todo = todoRepository.GetById(id);
            if (todo != null)
            {
                deleted = todoRepository.Delete(todo);
            }

            return deleted;
        }

        public bool Done(int id, bool done)
        {

            var returnDone = false;

            var todo = GetById(id);
            if (todo != null)
            {
                todo.Done = done;
                returnDone = todoRepository.Update(todo);
            }

            return returnDone;
        }

        public bool Edit(int id, string description)
        {
            var edited = false;

            var todoEdit = GetById(id);
            if (todoEdit != null)
            {
                todoEdit.Description = description;
                todoEdit.ModificationDate = DateTime.Now;
                edited = todoRepository.Update(todoEdit);
            }

            return edited;
        }

        public IQueryable<Todo> GetByUser(int userId)
        {
            return
                todoRepository.GetByUser(userId);
        }

        public Todo GetById(int id)
        {
            return
                todoRepository.GetById(id);
        }
    }
}
