using MediatR;
using ZooApi_Mediator.Application.DTOs;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdCommand : IRequest<BirdDto>
    {
        public string Name { get; }
        public string Description { get; }
        public string PhotoUrl { get; }

        public CreateBirdCommand(string name, string description, string photoUrl)
        {
            Name = name;
            Description = description;
            PhotoUrl = photoUrl;
        }
    }
}
