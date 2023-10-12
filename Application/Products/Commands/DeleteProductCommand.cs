using Domain.Entities;
using MediatR;

namespace Domain.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
