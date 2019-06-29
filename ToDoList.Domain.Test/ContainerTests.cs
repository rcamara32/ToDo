using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using TodoList.Ioc.Config;
using ToDoList.Domain.Contracts.Ioc;

namespace ToDoList.Domain.Test
{
    public class ContainerTests : IContainerApplication
    {

        private static ContainerTests containerTests;


        private static void Initialize()
        {
            if (containerTests == null)
                containerTests = new ContainerTests();
        }

        public static ContainerTests Container
        {
            get
            {
                Initialize();
                return containerTests;
            }
        }


        public static Scope BeginScope()
        {
            return ThreadScopedLifestyle.BeginScope(ContainerTests.Container._internalSimpleInjectorContainer);
        }

        private readonly SimpleInjector.Container _internalSimpleInjectorContainer;


        public ContainerTests()
        {
            _internalSimpleInjectorContainer = new SimpleInjector.Container();
            this.InitializeContainer();
        }



        public T GetService<T>()
        {
            return (T)_internalSimpleInjectorContainer.GetInstance(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _internalSimpleInjectorContainer.GetInstance(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_internalSimpleInjectorContainer.GetAllInstances(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _internalSimpleInjectorContainer.GetAllInstances(serviceType);
        }


        private void InitializeContainer()
        {
            _internalSimpleInjectorContainer.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
            BootStrapper.RegisterServices(_internalSimpleInjectorContainer);            
            _internalSimpleInjectorContainer.Verify();
        }


    }
}
