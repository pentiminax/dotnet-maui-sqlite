using SQLite;

namespace MyPasswordManager.Models;

public class LoginCrendential
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Website { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }
}
