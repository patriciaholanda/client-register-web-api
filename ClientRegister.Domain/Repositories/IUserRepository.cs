using ClientRegister.Domain.Entities;

namespace ClientRegister.Domain.Repositories;

public interface IUserRepository
{   
    public Task<List<User>> GetUsers();
    public Task<User> GetUserById(string userId);
    public Task AddUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(string userId);
}