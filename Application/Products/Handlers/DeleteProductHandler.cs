using Domain.Commands;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Domain.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
                throw new ProductNotFoundException(request.Id);
            }
            return await _productRepository.DeleteProduct(product);
        }
    }
}
