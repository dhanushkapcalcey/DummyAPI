using Domain.Commands;
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
            return await _productRepository.UpdateProduct(request.Id, request.Product);
        }
    }
}
