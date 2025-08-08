using MediatR;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public record DeleteBirdCommand(int Id) : IRequest<bool>
    {

    }
}
