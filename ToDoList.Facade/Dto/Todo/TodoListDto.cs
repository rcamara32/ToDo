using System;

namespace ToDoList.Facade.Dto.Todo
{
    public class TodoListDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Done { get; set; }
    }
}
