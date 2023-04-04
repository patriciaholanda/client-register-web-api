using ClientRegister.Domain.Entities;
using ClientRegister.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ClientRegister.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;
    private const string USERS_COLLECTION_NAME = "users";

    public UserRepository(IConfiguration configuration)
    {
        var mongoConnection = configuration.GetSection("MongoDB:ConnectionString").Value;
        var mongoDatabase = configuration.GetSection("MongoDB:DatabaseName").Value;

        var mongoClient = new MongoClient(mongoConnection);
        var database = mongoClient.GetDatabase(mongoDatabase);

        _users = database.GetCollection<User>(USERS_COLLECTION_NAME);
    }

    public async Task<List<User>> GetUsers() =>
        await _users.Find(_ => true).ToListAsync();

    public async Task<User> GetUserById(string userId) =>
        await _users.Find(x => x.Id == userId).FirstOrDefaultAsync();

    public async Task AddUser(User user) =>
        await _users.InsertOneAsync(user);

    public async Task UpdateUser(User user) =>
        await _users.ReplaceOneAsync(x => x.Id == user.Id, user);

    public async Task DeleteUser(string userId) =>
        await _users.DeleteOneAsync(x => x.Id == userId);
}