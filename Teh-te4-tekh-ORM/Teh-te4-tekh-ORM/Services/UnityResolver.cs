namespace Teh_te4_tekh_ORM.Services
{
    using System.Web.Http.Dependencies;
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            IUnityContainer child = this.container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}