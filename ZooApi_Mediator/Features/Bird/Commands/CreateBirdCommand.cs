using MediatR;

namespace ZooApi_Mediator.Features.Bird.Commands
{
    public class CreateBirdCommand : IRequest<ZooApi_Mediator.Entities.Bird>
    {
    }
}
