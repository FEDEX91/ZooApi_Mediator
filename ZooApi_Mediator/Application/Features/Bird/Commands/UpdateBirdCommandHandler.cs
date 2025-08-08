using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class UpdateBirdCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateBirdCommand, BirdDto?>
    {
        public async Task<BirdDto?> Handle(UpdateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = await unitOfWork.Birds.GetByIdAsync(request.Bird.Id);

            if (bird is null) return null;

            bird.Name = request.Bird.Name;
            bird.Description = request.Bird.Description;
            bird.PhotoUrl = request.Bird.PhotoUrl;

            unitOfWork.Birds.Update(bird);
            await unitOfWork.SaveChangesAsync();

            return request.Bird;
        }
    }
}
