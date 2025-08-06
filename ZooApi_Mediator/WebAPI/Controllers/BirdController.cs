using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZooApi_Mediator.Application.Features.Bird.Commands;
using ZooApi_Mediator.Application.Features.Bird.Queries;

namespace ZooApi_Mediator.WebAPI.Controllers
{
    public class BirdController(IMediator mediator) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var birds = await mediator.Send(new GetBirdQuery());
            return Ok(birds);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBirdCommand command)
        {
            var bird = await mediator.Send(command);
            return Ok(bird);
        }
    }
}
