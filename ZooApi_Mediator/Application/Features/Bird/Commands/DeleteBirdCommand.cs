using MediatR;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class DeleteBirdCommand(int id) : IRequest<bool>
    {
        public int Id { get; } = id;
    }
}
