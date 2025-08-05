using MediatR;

namespace ZooApi_Mediator.Application.Features.Bird.Queries
{
    public class GetBirdQuery : IRequest<IEnumerable<Domain.Entities.Bird>>
    {
    }
}
