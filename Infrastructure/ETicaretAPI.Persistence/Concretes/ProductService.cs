using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        => new() 
        {
            new() { Id= Guid.NewGuid() , Name ="Product 1" , Price= 100, Stock =10 },
            new() { Id= Guid.NewGuid() , Name ="Product 2" , Price= 10, Stock =4},
            new() { Id= Guid.NewGuid() , Name ="Product 3" , Price= 120, Stock =120 },
            new() { Id= Guid.NewGuid() , Name ="Product 4" , Price= 180, Stock =100 },
            new() { Id= Guid.NewGuid() , Name ="Product 5" , Price= 300, Stock =102 },
            new() { Id= Guid.NewGuid() , Name ="Product 6" , Price= 1000, Stock =1044 },
        };
    }
}
