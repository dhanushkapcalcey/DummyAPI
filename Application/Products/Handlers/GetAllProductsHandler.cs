using Domain.Entities;
using Domain.Interfaces;
using Domain.Queries;
using MediatR;

namespace Domain.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsHandler(IProductRepository repository)
        {
            _productRepository = repository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts();
        }
    }
}
