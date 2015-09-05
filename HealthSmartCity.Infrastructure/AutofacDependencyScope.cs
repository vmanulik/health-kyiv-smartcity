using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Autofac;

namespace HealthSmartCity.Infrastructure
{
    public class AutofacDependencyScope : IDependencyScope
    {
        private ILifetimeScope _container;

        public AutofacDependencyScope(ILifetimeScope container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            object instance = null;
            _container.TryResolve(serviceType, out instance);

            return instance;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            Type arrayType = typeof(IEnumerable<>).MakeGenericType(serviceType);

            return (IEnumerable<object>)_container.Resolve(arrayType);
        }

        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
            }

            _container = null;

        }
    }
}
