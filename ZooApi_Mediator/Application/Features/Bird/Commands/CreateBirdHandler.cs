using MediatR;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdHandler : IRequestHandler<CreateBirdCommand, Domain.Entities.Bird>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBirdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Domain.Entities.Bird> Handle(CreateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = new Domain.Entities.Bird
            {
                Name = "test"
            };

            await _unitOfWork.Birds.AddAsync(bird);
            await _unitOfWork.SaveChangesAsync();

            return bird;
        }
    }
}
