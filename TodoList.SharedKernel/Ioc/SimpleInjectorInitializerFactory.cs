using SimpleInjector;

namespace TodoList.SharedKernel.Ioc
{

    public static class SimpleInjectorInitializerFactory
    {
        private static Container _container;

        public static void SetContainer(Container container)
        {
            _container = container;
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }

}
