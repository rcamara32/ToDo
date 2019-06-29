namespace ToDoList.Repository.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDoList.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoList.Repository.Context.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoList.Repository.Context.TodoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<User> users = new List<User>();
            users.Add(new User() { Name = "Renan Camara", UserName = "renan.camara", Password = "renan123" });
            users.Add(new User() { Name = "Deloitte", UserName = "deloitte.ireland", Password = "deloitte123" });
            context.User.AddRange(users);

            context.SaveChanges();

            IList<Todo> todos = new List<Todo>();
            todos.Add(new Todo { Description = "Make Resume", ModificationDate = DateTime.Now.AddDays(-5), Done = true,
                UserId = context.User.FirstOrDefault(x => x.UserName == "renan.camara").Id
            });
            todos.Add(new Todo { Description = "Send Resume to Deloitte", ModificationDate = DateTime.Now.AddDays(-3), Done = true,
                UserId = context.User.FirstOrDefault(x => x.UserName == "renan.camara").Id
            });
            todos.Add(new Todo { Description = "Make Interview with David Lyons", ModificationDate = DateTime.Now.AddDays(-2), Done = true ,
                UserId = context.User.FirstOrDefault(x => x.UserName == "renan.camara").Id
            });
            todos.Add(new Todo { Description = "Get Hired!", ModificationDate = DateTime.Now, Done = false,
                UserId = context.User.FirstOrDefault(x => x.UserName == "renan.camara").Id
            });

            context.Todo.AddRange(todos);

            base.Seed(context);

        }
    }
}
