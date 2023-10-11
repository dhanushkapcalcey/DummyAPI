using API.Entities;
using MediatR;

namespace API.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product _product { get; set; }

        public AddProductCommand(Product product)
        {
            _product = product;
        }
    }
}
