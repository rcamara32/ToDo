using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using ToDoList.Domain.Contracts.Ioc;

namespace TodoList.Ioc.Containers
{
    public class ContainerApplication : IContainerApplication
    {

        private readonly IDependencyResolver _resolver;

        public ContainerApplication(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public T GetService<T>()
        {
            return (T)_resolver.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_resolver.GetServices(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }

    }
}
