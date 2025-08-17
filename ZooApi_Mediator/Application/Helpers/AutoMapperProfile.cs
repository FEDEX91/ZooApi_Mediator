﻿using AutoMapper;
using ZooApi_Mediator.Application.DTOs;
using ZooApi_Mediator.Domain.Entities;

namespace ZooApi_Mediator.Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BirdDto, Bird>();
            CreateMap<Bird, BirdDto>();
            CreateMap<BirdSingleDto, Bird>();
            CreateMap<Bird, BirdSingleDto>();

            CreateMap<Fish, FishDto>();
            CreateMap<FishDto, Fish>();
            CreateMap<FishSingleDto, Fish>();
            CreateMap<Fish, FishSingleDto>();
        }
    }
}
