namespace ClientRegister.Domain.ValueObjects.UserVOs;

public class AddUserVO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public AddUserVO(string name, string email, string password)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }
}