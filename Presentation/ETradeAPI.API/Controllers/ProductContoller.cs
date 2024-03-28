using ETradeAPI.Application.Repositories;
using ETradeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContoller : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductContoller(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new(){ Id=Guid.NewGuid(), Name="Product 1", Price=100,CreatedDate=DateTime.UtcNow, Stock=10 },
            //    new(){ Id=Guid.NewGuid(), Name="Product 2s", Price=200,CreatedDate=DateTime.UtcNow, Stock=13 },
            //    new(){ Id=Guid.NewGuid(), Name="Product 3", Price=500,CreatedDate=DateTime.UtcNow, Stock=15 },
            //    new(){ Id=Guid.NewGuid(), Name="Product 4", Price=400,CreatedDate=DateTime.UtcNow, Stock=16 },

            //});

            //await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("30b57909-d7d2-4431-964a-92cca51fbc6a",false);
            p.Name = "Habip";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
