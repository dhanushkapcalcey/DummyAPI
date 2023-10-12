using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Domain.Handlers
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
            _productRepository.AddProduct(request.Product);
            await _productRepository.SaveAllAsync();
            return request.Product;
        }

    }
}
