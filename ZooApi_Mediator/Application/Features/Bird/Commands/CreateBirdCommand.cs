using MediatR;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdCommand : IRequest<Domain.Entities.Bird>
    {
    }
}
