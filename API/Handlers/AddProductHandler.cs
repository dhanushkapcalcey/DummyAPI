using API.Commands;
using API.Entities;
using API.Interfaces;
using MediatR;

namespace API.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.AddProduct(request._product);
            await _productRepository.SaveAllAsync();
            return request._product;
        }

    }
}
