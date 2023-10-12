using Domain.Entities;
using MediatR;

namespace Domain.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

    }
}
