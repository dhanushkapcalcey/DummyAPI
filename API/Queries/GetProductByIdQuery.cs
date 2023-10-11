using API.Entities;
using MediatR;

namespace API.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid ProductId { get; }
        public GetProductByIdQuery(Guid id) 
        {
            ProductId = id;
        }
    }
}
