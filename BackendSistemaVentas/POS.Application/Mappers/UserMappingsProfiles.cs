using AutoMapper;
using POS.Application.Dtos.User.Request;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class UserMappingsProfiles : Profile
    {
        public UserMappingsProfiles()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }
    }
} 
