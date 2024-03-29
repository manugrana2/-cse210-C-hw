public abstract class User
{
    protected string _name;
    protected string _lastName;
    protected string _password;

    public User(string name, string lastName, string password)
    {
        _name = name;
        _lastName = lastName;
        _password = password;
    }

    public string GetName() => _name;
    public string GetLastName() => _lastName;
    public abstract string GetType();
}
