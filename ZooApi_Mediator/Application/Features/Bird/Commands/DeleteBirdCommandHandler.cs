using MediatR;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class DeleteBirdCommandHandler : IRequestHandler<DeleteBirdCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBirdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = await _unitOfWork.Birds.GetByIdAsync(request.Id);
            if (bird is null) return false;

            _unitOfWork.Birds.Remove(bird);
            await _unitOfWork.SaveChangesAsync();
            return true; 
        }
    }
}
