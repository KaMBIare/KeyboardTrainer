namespace Domain.Entities;

public class User : BaseEntity
{
    public User()
    {
        
    }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
    public string Login { get; set; }
    public string Password { get; set; }
}