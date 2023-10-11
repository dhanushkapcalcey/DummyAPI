using API.DTOs;
using MediatR;

namespace API.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid _id {  get; set; }
        public ProductDto _productDto { get; set; }
        UpdateProductCommand(Guid id, ProductDto productDto) 
        {
            _id = id;
            _productDto = productDto;
        }

    }
}
