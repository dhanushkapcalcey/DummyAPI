using Domain.Entities;
using MediatR;

namespace Domain.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }

        public AddProductCommand(Product product)
        {
            Product = product;
        }
    }
}
