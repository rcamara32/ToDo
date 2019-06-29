using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using TodoList.SharedKernel.Ioc;

namespace TodoList.Ioc.Config
{
    public static class SimpleInjectorAppInitializer
    {

        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            var injector = new SimpleInjectorDependencyResolver(container);

            DependencyResolver.SetResolver(injector);
            
            SimpleInjectorInitializerFactory.SetContainer(container);

            container.Verify();
        }

        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);
        }

    }
}
