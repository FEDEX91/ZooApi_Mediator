using MediatR;
using ZooApi_Mediator.Entities;
using ZooApi_Mediator.Interfaces;

namespace ZooApi_Mediator.Features.Bird.Commands
{
    public class CreateBirdHandler : IRequestHandler<CreateBirdCommand, ZooApi_Mediator.Entities.Bird>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBirdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Entities.Bird> Handle(CreateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = new ZooApi_Mediator.Entities.Bird
            {
                Name = "test"
            };

            await _unitOfWork.Birds.AddAsync(bird);
            await _unitOfWork.SaveChangesAsync();

            return bird;
        }
    }
}
