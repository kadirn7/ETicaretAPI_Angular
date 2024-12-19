using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
                
        
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
          {
            await _productWriteRepository.AddRangeAsync(new()
              {
        new() {Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10},
             });
            await _productWriteRepository.SaveAsync();

            return Ok("Products added successfully");
        }

    }
}
