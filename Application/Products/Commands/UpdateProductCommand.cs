using Domain.Entities;
using MediatR;

namespace Domain.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public UpdateProductCommand(Guid id, Product productDto)
        {
            Id = id;
            Product = productDto;
        }
    }
}
