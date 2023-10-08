using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                Id = Guid.NewGuid()
            };
            _productRepository.AddProduct(product);
            await _productRepository.SaveAllAsync();

            return CreatedAtAction("GetProductById", new { productId = product.Id }, product);
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

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductById(string productId)
        {
            Guid producGuid;
            try
            {
                producGuid = Guid.Parse(productId);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            var product = await _productRepository.GetProductById(producGuid);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPatch("{productId}")]
        public async Task<ActionResult<Product>> UpdateProduct(ProductDto productDto, 
            string productId) 
        {
            Guid productGuid;
            try
            {
                productGuid = Guid.Parse(productId);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            var product = await _productRepository.GetProductById(productGuid);
            if (product == null)
            {
                return NotFound();
            }

            product.Quantity = productDto.Quantity;
            product.Price = productDto.Price;
            product.Name = productDto.Name;
            if (await _productRepository.SaveAllAsync()) return Ok(_mapper.Map<Product, ProductDto>(product));

            return BadRequest("Failed to update user");
        }

        //[HttpPut("{productId}")]
        //public Task<ActionResult<Product>>

    }
}
