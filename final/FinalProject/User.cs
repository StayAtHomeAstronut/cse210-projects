class User
{
    public string Username { get; set; }
    private string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}