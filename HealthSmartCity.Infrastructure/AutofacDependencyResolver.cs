using System;
using System.Collections.Generic;
using MVC = System.Web.Mvc;
using WepAPI = System.Web.Http.Dependencies;
using Autofac;

namespace HealthSmartCity.Infrastructure
{
    public class AutofacDependencyResolver : MVC.IDependencyResolver, WepAPI.IDependencyResolver
    {
        public AutofacDependencyResolver(IContainer container)
        {
            _container = container;
        }

        private readonly IContainer _container;
   
        #region IDependencyResolver implementation

        public object GetService(Type serviceType)
        {
            if (!_container.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }
            return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Type typeToResolve = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return _container.Resolve(typeToResolve) as IEnumerable<object>;
        }

        public WepAPI.IDependencyScope BeginScope()
        {
            return new AutofacDependencyScope(_container.BeginLifetimeScope());
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        #endregion
    }
}