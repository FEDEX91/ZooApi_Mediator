using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZooApi_Mediator.Features.Bird.Queries;

namespace ZooApi_Mediator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BirdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BirdController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var birds = await _mediator.Send(new GetBirdQuery());
            return Ok(birds);
        }
    }
}
