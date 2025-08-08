using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateBirdCommand, BirdDto>
    {
        public async Task<BirdDto> Handle(CreateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = mapper.Map<Domain.Entities.Bird>(request.BirdDto);

            await unitOfWork.Birds.AddAsync(bird);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<BirdDto>(bird);
        }
    }
}
