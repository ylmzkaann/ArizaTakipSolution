using AutoMapper;
using ArizaTakip.Domain;
using ArizaTakip.Application.Dtos;

namespace ArizaTakip.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Request -> RequestListDto
            CreateMap<Request, RequestListDto>()
                .ForMember(d => d.CreatedByName, opt => opt.MapFrom(s => s.CreatedBy != null ? s.CreatedBy.Name : string.Empty))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));

            // RequestCreateDto -> Request
            CreateMap<RequestCreateDto, Request>();

            // User -> UserDto
            CreateMap<User, UserDto>();

            // UserCreateDto -> User
            CreateMap<UserCreateDto, User>();
        }
    }
}