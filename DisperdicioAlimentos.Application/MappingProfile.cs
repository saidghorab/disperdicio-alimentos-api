using AutoMapper;
using DisperdicioAlimentos.Application.DTOs;
using DisperdicioAlimentos.Domain.Entities;

namespace DisperdicioAlimentos.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FoodItem, FoodItemDto>().ReverseMap();
        }
    }
}
