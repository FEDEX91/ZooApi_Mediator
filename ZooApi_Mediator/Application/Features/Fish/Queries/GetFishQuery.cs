using MediatR;
using ZooApi_Mediator.Application.DTOs;

namespace ZooApi_Mediator.Application.Features.Fish.Queries
{
    public class GetFishQuery : IRequest<IEnumerable<FishSingleDto>>
    {
    }
}
