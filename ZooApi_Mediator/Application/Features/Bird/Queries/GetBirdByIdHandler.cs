using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public class GetBirdByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetBirdByIdQuery, BirdSingleDto?>
    {
        public async Task<BirdSingleDto?> Handle(GetBirdByIdQuery request, CancellationToken cancellationToken)
        {
            var bird = await unitOfWork.Birds.GetByIdAsync(request.Id);

            if (bird is null) return null;

            var result = mapper.Map<BirdSingleDto>(bird);

            return result;
        }
    }
}
