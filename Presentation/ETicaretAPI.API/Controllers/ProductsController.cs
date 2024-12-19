using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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



        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {
            await _productWriteRepository.AddRangeAsync(new()
    {
        new() {Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10},
    });
            await _productWriteRepository.SaveAsync();

            return Ok("Products added successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
