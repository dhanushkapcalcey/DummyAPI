using API.Commands;
using API.Interfaces;
using MediatR;

namespace API.Handlers
{
    public class UpdateProductHandler : IRequestHandler<updateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(updateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.UpdateProduct(request._id, request._productDto);
        }
    }
}
