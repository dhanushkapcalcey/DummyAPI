using API.Entities;
using MediatR;

namespace API.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Product _product { get; set; }
        public DeleteProductCommand(Product product)
        {
            _product = product;
        }
    }
}
