using AutoMapper;
using EfCore.AuditInterceptor.Api.Models.Dtos;
using EfCore.AuditInterceptor.Domain.Entities;

namespace EfCore.AuditInterceptor.Api.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}