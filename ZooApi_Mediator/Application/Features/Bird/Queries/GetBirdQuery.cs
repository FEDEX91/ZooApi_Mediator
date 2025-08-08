using MediatR;
using ZooApi_Mediator.Application.DTOs;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public class GetBirdQuery : IRequest<IEnumerable<BirdSingleDto>>
    {
    }
}
