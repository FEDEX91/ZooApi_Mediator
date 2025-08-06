﻿using AutoMapper;
using MediatR;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Interfaces;

namespace ZooApi_Mediator.Application.Features.Bird.Commands
{
    public class CreateBirdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateBirdCommand, BirdDto>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BirdDto> Handle(CreateBirdCommand request, CancellationToken cancellationToken)
        {
            var bird = this._mapper.Map<Domain.Entities.Bird>(request.BirdDto);

            await _unitOfWork.Birds.AddAsync(bird);
            await _unitOfWork.SaveChangesAsync();

            return this._mapper.Map<BirdDto>(bird);
        }
    }
}
