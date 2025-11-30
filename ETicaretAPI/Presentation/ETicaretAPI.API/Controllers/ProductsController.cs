using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id = Guid.NewGuid(),Name="Product 1", Price=100, Stock=10, CreatedDate= DateTime.UtcNow},
                new(){ Id = Guid.NewGuid(),Name="Product 2", Price=100, Stock=10, CreatedDate= DateTime.UtcNow},
                new(){ Id = Guid.NewGuid(),Name="Product 3", Price=100, Stock=10, CreatedDate= DateTime.UtcNow},
            });
             var count = await _productWriteRepository.SaveAsync();

        }
    }
}
