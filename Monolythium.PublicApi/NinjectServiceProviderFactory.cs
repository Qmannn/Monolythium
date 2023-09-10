using Microsoft.Extensions.DependencyInjection;
using Monolythium.DependencyManagement;
using Ninject;
using System.Net;

namespace Monolythium.PublicApi
{
    public class Builder
    {
        private readonly IServiceCollection _services;
        private readonly Func<IServiceCollection, IServiceProvider> _servideProviderFactory;

        public Builder(IServiceCollection services, Func<IServiceCollection, IServiceProvider> servideProviderFactory)
        {
            _services = services;
            _servideProviderFactory = servideProviderFactory;
        }

        public IServiceProvider CreateServiceProvider()
        {
            BaseDependencyModule rootModule2 = new PublicApiModule();
            var transientKernel = new StandardKernel();


            transientKernel.Load(rootModule2.GetModulesForCompositionRoot());
            return new CompinedServiceProvider(_servideProviderFactory(_services), transientKernel);
        }
    }

    public class NinjectServiceProviderFactory : IServiceProviderFactory<Builder>
    {
        private readonly Func<IServiceCollection, IServiceProvider> _servideProviderFactory;

        public NinjectServiceProviderFactory(Func<IServiceCollection, IServiceProvider> servideProviderFactory)
        {
            _servideProviderFactory = servideProviderFactory;
        }

        public Builder CreateBuilder(IServiceCollection services)
        {
            return new Builder(services, _servideProviderFactory);
        }

        public IServiceProvider CreateServiceProvider(Builder containerBuilder)
        {
            return containerBuilder.CreateServiceProvider();
        }
    }

    public class CompinedServiceProvider : IServiceProvider
    {
        private readonly IServiceProvider _provider1;
        private readonly IServiceProvider _provider2;

        public CompinedServiceProvider(IServiceProvider provider1, IServiceProvider provider2)
        {
            _provider1 = provider1;
            _provider2 = provider2;
        }


        public object? GetService(Type serviceType)
        {
            if (serviceType == typeof(IServiceProvider))
            {
                throw new ArgumentException();
            }

            return _provider1.GetService(serviceType);
        }
    }


}
