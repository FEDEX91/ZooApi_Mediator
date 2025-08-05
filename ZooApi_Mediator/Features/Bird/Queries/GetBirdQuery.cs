using MediatR;

namespace ZooApi_Mediator.Features.Bird.Queries
{
    public class GetBirdQuery : IRequest<IEnumerable<Entities.Bird>>
    {
    }
}
