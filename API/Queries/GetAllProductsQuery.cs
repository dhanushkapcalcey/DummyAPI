using API.Entities;
using MediatR;

namespace API.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
