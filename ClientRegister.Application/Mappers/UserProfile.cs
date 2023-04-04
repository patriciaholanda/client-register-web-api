using AutoMapper;
using ClientRegister.Application.Models.UserModels;
using ClientRegister.Domain.Entities;
using ClientRegister.Domain.ValueObjects.UserVOs;

namespace ClientRegister.Application.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, AddUserVO>().ReverseMap();
        CreateMap<User, UserModel>().ReverseMap();
    }
}