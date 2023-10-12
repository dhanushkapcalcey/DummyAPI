using Domain.Entities;
using MediatR;

namespace Domain.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Product Product { get; set; }
        public DeleteProductCommand(Product product)
        {
            Product = product;
        }
    }
}
