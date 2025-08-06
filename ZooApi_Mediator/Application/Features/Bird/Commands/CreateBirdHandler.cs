using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdHandler : IRequestHandler<CreateBirdCommand, BirdDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBirdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BirdDto> Handle(CreateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = new Domain.Entities.Bird
            {
                Name = request.BirdDto.Name,
                Description = request.BirdDto.Description,
                PhotoUrl = request.BirdDto.PhotoUrl,
            };

            await _unitOfWork.Birds.AddAsync(bird);
            await _unitOfWork.SaveChangesAsync();

            return new BirdDto { Name = bird.Name, Description = bird.Description, PhotoUrl = bird.PhotoUrl};
        }
    }
}
