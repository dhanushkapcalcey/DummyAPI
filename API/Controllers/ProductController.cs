using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto productDto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                Id = new Guid()
            };
            _productRepository.AddProduct(product);
            await _productRepository.SaveAllAsync();

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetProducts();

            if (!products.Any())
            {
                return NoContent();
            }

            return Ok(products);
        }




    }
}
