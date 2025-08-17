using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZooApi_Mediator.Application.Features.Fish.Queries;

namespace ZooApi_Mediator.WebAPI.Controllers
{
    public class FishController(IMediator mediator) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fishes = await mediator.Send(new GetFishQuery());
            return Ok(fishes);
        }
    }
}
