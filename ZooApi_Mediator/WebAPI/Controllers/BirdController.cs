﻿using MediatR;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteBirdCommand(id));
            if (!result) return NotFound($"Id {id} not found.");
            return NoContent();
        }
    }
}
