using ArizaTakip.Application.Dtos;
using ArizaTakip.Domain;
using AutoMapper;

namespace ArizaTakip.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RequestCreateDto, Request>();
            CreateMap<Request, RequestListDto>();
            CreateMap<Request, UpdateRequestStatusDto>().ReverseMap();
        }
    }
}