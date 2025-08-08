using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZooApi_Mediator.Application.DTOs;
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
        public async Task<IActionResult> Create([FromBody]BirdDto birdDto)
        {
            var bird = await mediator.Send(new CreateBirdCommand(birdDto));
            return Ok(bird);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var result = await mediator.Send(new DeleteBirdCommand(id));
            if (!result) return NotFound($"Record id {id} not found.");
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]BirdDto birdDto)
        {
            birdDto.Id = id;

            var result = await mediator.Send(new UpdateBirdCommand(birdDto));

            if (result is null) return NotFound($"Record id {id} not found.");

            return NoContent();
        }
    }
}
