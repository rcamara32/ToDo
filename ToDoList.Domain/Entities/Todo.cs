using System;

namespace ToDoList.Domain.Entities
{
    public class Todo
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Done { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
