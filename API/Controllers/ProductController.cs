using API.DTOs;
using AutoMapper;
using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Queries;
using MediatR;
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
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto productDto)
        {
            var newProduct = new Product(productDto.Name,
                productDto.Price, productDto.ImageUrl, productDto.Quantity);
            var command = new AddProductCommand(newProduct);
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
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPatch("{productId}")]
        public async Task<ActionResult<Product>> UpdateProduct(UpdateProductDto updateProductDto, 
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
            
            var product = _mapper.Map<Product>(updateProductDto);

            var command = new UpdateProductCommand(productGuid, product);
            var result = await _mediator.Send(command);
            if (result) return Ok();

            return BadRequest("Failed to update product");
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

            var deleteCommand = new DeleteProductCommand(productGuid);
            if (await _mediator.Send(deleteCommand)) return Ok();

            return BadRequest("Failed to delete product");
            
        }
    }
}
