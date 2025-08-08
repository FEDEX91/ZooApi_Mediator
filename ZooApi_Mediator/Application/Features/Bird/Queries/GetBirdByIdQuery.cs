using MediatR;
using ZooApi_Mediator.Application.DTOs;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public record GetBirdByIdQuery(int Id) : IRequest<BirdSingleDto>
    {
    }
}
