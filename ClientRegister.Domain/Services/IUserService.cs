using ClientRegister.Domain.Entities;
using ClientRegister.Domain.ValueObjects.UserVOs;

namespace ClientRegister.Domain.Services;

public interface IUserService
{
    public Task<List<User>> GetUsers();
    public Task<User> GetUserById(string userId);
    public Task<User> AddUser(AddUserVO userVO);
    public Task UpdateUser(UpdateUserVO userVO);
    public Task DeleteUser(string userId);
}