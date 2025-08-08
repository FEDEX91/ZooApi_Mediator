using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public class GetBirdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetBirdQuery, IEnumerable<BirdSingleDto>>
    {
        public async Task<IEnumerable<BirdSingleDto>> Handle(GetBirdQuery request, CancellationToken cancellationToken)
        {
            var birds = await unitOfWork.Birds.GetAllAsync();
            var result = mapper.Map<IEnumerable<BirdSingleDto>>(birds);
            return result;
        }
    }
}
