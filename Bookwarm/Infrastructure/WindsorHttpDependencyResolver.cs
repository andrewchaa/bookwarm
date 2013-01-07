using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;

namespace Bookwarm.Infrastructure
{
    public class WindsorHttpDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public WindsorHttpDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return _kernel.Resolve<IDependencyScope>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.HasComponent(serviceType) ? _kernel.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.HasComponent(serviceType)
                       ? _kernel.ResolveAll(serviceType) as IEnumerable<object>
                       : Enumerable.Empty<object>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}