using AutoMapper;
using ClientRegister.Domain.Entities;
using ClientRegister.Domain.Repositories;
using ClientRegister.Domain.Services;
using ClientRegister.Domain.ValueObjects.UserVOs;

namespace ClientRegister.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User> GetUserById(string userId)
    {
        var user = await _userRepository.GetUserById(userId);
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        return users;
    }

    public async Task<User> AddUser(AddUserVO userVO)
    {
        User user = _mapper.Map<User>(userVO);
        await _userRepository.AddUser(user);
        return user;
    }
    
    public async Task UpdateUser(UpdateUserVO userVO)
    {
        User user = _mapper.Map<User>(userVO);
        await _userRepository.UpdateUser(user);
    }

    public async Task DeleteUser(string userId)
    {
        await _userRepository.DeleteUser(userId);
    }
}