using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
         
        {
            
            services.AddDbContext<ETicaretDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

           // services.AddSingleton<IProductService, ProductService>();
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }   
    }
}
