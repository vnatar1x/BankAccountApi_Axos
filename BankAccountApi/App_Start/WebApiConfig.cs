using Unity;
using AutoMapper;
using Unity.WebApi;
using System.Web.Http;
using BankAccountApi.Mappers;
using BankAccountApi.DependencyInjection;
using BankAccountApi_BusinessLayer.Providers.Interfaces;
using BankAccountApi_DataAccessLayer.DataAccess.Interfaces;
using BankAccountApi_BusinessLayer.Providers.Implementations;
using BankAccountApi_DataAccessLayer.DataAccess.Implementations;

namespace BankAccountApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Registering container
            UnityContainer container = RegisterContainer(config);

            //Registering mappers
            IMapper mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
            container.RegisterInstance<IMapper>(mapper);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static UnityContainer RegisterContainer(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IAccountProvider, AccountProvider>();
            container.RegisterType<ICustomerProvider, CustomerProvider>();
            container.RegisterType<IAccountRepo, AccountRepo>();
            container.RegisterType<ICustomerRepo, CustomerRepo>();
            container.RegisterType<IDatabaseWrapper, DatabaseWrapper>();

            config.DependencyResolver = new UnityResolver(container);
            config.DependencyResolver = new UnityDependencyResolver(container);

            return container;
        }
    }
}
