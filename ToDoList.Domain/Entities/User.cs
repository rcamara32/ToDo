using System.Collections.Generic;

namespace ToDoList.Domain.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }


    }
}
