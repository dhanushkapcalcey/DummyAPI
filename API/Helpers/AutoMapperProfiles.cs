using API.DTOs;
using AutoMapper;
using Domain.Entities;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
