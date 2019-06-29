using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ToDoList.Domain.Entities;
using ToDoList.Repository.Mapping;

namespace ToDoList.Repository.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext()
            : base("DefaultConnection")
        {
        }

        public static TodoContext Create()
        {
            return new TodoContext();
        }

        public DbSet<Todo> Todo { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove pluralization for entities name.
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Configurations.Add(new TodoMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

    }
}
