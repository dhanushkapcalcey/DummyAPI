using API.Commands;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Queries;
using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;

        public ProductController(IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,
                Id = Guid.NewGuid()
            };
            var command = new AddProductCommand(product);
            var createdProduct = await _mediator.Send(command);

            return CreatedAtAction("GetProductById", new { productId = createdProduct.Id }, createdProduct);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var products = await _mediator.Send(query);

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

            var query = new GetProductByIdQuery(producGuid);
            var product = await _mediator.Send(query);
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

            var command = new UpdateProductCommand(productGuid, productDto);
            var result = await _mediator.Send(command);
            if (result) return Ok();

            return BadRequest("Failed to update user");
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProudctById(string productId) 
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

            var query = new GetProductByIdQuery(productGuid);
            var product = await _mediator.Send(query);
            if (product == null) return NotFound(productId);

            var deleteCommand = new DeleteProductCommand(product);
            await _mediator.Send(deleteCommand);

            if (await _productRepository.SaveAllAsync()) return Ok("deleted");

            return BadRequest("Failed to delete user");
        }
    }
}
