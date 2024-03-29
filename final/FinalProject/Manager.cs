public class Manager : User
{
    private string _type = "Manager";

    public Manager(string name, string lastName, string password) : base(name, lastName, password) { }

    public override string GetType() => _type;
}
