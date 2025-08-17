using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Fish.Queries
{
    public class GetFishHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetFishQuery, IEnumerable<FishSingleDto>>
    {
        public async Task<IEnumerable<FishSingleDto>> Handle(GetFishQuery request, CancellationToken cancellationToken)
        {
            var fishes = await unitOfWork.Fishes.GetAllAsync();
            var result = mapper.Map<IEnumerable<FishSingleDto>>(fishes);
            return result;
        }
    }
}
