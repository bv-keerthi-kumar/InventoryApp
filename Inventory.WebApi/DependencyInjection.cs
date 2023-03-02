using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services;
using Inventory.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.WebApi
{
    public  class DependencyInjection
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IInventoryService, InventoryService>();
            
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
                    
        }
    }
}
