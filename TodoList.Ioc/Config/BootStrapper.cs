using SimpleInjector;
using ToDoList.Domain.Contracts.Repository;
using ToDoList.Domain.Contracts.Service;
using ToDoList.Domain.Services;
using ToDoList.Facade.Contracts;
using ToDoList.Facade.Services;
using ToDoList.Repository.Context;
using ToDoList.Repository.Repositories;

namespace TodoList.Ioc.Config
{
    public class BootStrapper
    {

        private BootStrapper()
        {
        }

        public static void RegisterServices(Container container)
        {
            RegisterApp(container);
            RegisterDomain(container);
            RegisterRepository(container);
            RegisterContext(container);
        }

        private static void RegisterApp(Container container)
        {
            container.Register<ITodoApp, TodoApp>(Lifestyle.Scoped);
            container.Register<ILoginApp, LoginApp>(Lifestyle.Scoped);
        }

        private static void RegisterDomain(Container container)
        {
            container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
        }

        private static void RegisterRepository(Container container)
        {
            container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
        }

        private static void RegisterContext(Container container)
        {
            container.Register<TodoContext, TodoContext>(Lifestyle.Scoped);
        }


    }
}
