using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClientRegister.Domain.Entities;

public class User
{
    [BsonId]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public User()
    {
        Id = ObjectId.GenerateNewId().ToString();
    }
}