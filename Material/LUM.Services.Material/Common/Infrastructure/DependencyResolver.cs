using System;
using Akka.Actor;
using AutoMapper;
using LUM.Services.Material.Actor;
using LUM.Services.Material.Common.Persistence;
using LUM.Services.Material.Mapper;
using LUM.Services.Material.Repository;
using LUM.Services.Material.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;

namespace LUM.Services.Material.Common.Infrastructure
{
    public static class DependencyResolver
    {
        public static void Resolve(this IServiceCollection services, Setting setting)
        {

            services.AddSingleton<IDocumentStore>(x =>
                {
                    var store = new DocumentStore()
                    {
                        Urls = new[] { setting.Database.Address },
                        Database = setting.Database.Name,

                        Conventions = { }
                    }.Initialize();
                    (new DatabaseInitializer().EnsureDatabaseExistsAsync(store, setting.Database.Name)).GetAwaiter().GetResult();
                    IndexCreation.CreateIndexes(typeof(MaterialSearchByNameIndex).Assembly, store);
                    return store;
                }
            );

            services.AddTransient<MaterialRepository>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "LUM Material Microservice", Version = "v1" });
            });

            services.AddAutoMapper(
                configuration => configuration.AddProfile<MaterialProfile>(),
                AppDomain.CurrentDomain.GetAssemblies());

  
            services.AddSingleton(_ => ActorSystem.Create("MaterialMicroservice", ActorConfigurationLoader.Load()));

            var serviceProvider = services.BuildServiceProvider();
            var mapper = serviceProvider.GetService<IMapper>();
            var materialRepository= serviceProvider.GetService<MaterialRepository>();

            services.AddSingleton<MaterialSupervisorProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                var materialActor = actorSystem.ActorOf(Props.Create(() => new MaterialActor(materialRepository,mapper)));
                return () => materialActor;
            });

        }
        private static string GetXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "Test.Microservice.Material.xml");
        }
    }
}

