using Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace BankAccountApi.DependencyInjection
{
    /// <summary>
    /// Responsible for resolving the members inside the container
    /// </summary>
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Resolve type
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch(ResolutionFailedException ex)
            {
                //TODO logging
                return null;
            }
        }

        /// <summary>
        /// Resolve types
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                //TODO logging
                return null;
            }
        }

        /// <summary>
        /// Scope the container to child
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            IUnityContainer child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        /// <summary>
        /// free the _container
        /// </summary>
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}