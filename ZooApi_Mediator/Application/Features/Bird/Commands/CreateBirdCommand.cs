using MediatR;
using ZooApi_Mediator.Application.DTOs;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public record CreateBirdCommand(BirdDto BirdDto) : IRequest<BirdDto>
    {
    }
}
