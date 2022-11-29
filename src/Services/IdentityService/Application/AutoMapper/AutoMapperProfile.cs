using AutoMapper;
using Domain.Entity;
using Identity.Shared.Dto;

namespace Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserListDto>().ReverseMap();
        }
    }
}
