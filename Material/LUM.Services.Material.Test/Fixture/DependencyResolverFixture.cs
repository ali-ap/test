using System;
using LUM.Services.Material.Common.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LUM.Services.Material.Test.Fixture
{
    public class DependencyResolverFixture : IDisposable
    {
        public readonly Setting Setting;

        public DependencyResolverFixture()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<Setting>(configuration.GetSection(nameof(Common.Infrastructure.Setting)));
            Setting = configuration.GetSection(nameof(Common.Infrastructure.Setting)).Get<Setting>();
            serviceCollection.Resolve(Setting);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider = null;
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}