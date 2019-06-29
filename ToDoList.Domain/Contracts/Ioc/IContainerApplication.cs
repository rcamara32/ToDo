using System;
using System.Collections.Generic;

namespace ToDoList.Domain.Contracts.Ioc
{
    public interface IContainerApplication
    {
        T GetService<T>();
        object GetService(Type serviceType);
        IEnumerable<T> GetServices<T>();
        IEnumerable<object> GetServices(Type serviceType);
    }
}
