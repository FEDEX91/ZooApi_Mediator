using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
