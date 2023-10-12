using Domain.Commands;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Domain.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
               throw new ProductNotFoundException(request.Id);
            }

            product.Name = request.Product.Name;
            product.Price = request.Product.Price;
            product.ImageUrl = request.Product.ImageUrl;
            product.Quantity = request.Product.Quantity;
            return await _productRepository.SaveAllAsync();
        }
    }
}
