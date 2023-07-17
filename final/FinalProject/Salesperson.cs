public class Salesperson : User
{
    private string _type = "Salesperson";

    public Salesperson(string name, string lastName, string password) : base(name, lastName, password) { }

    public override string GetType() => _type;
}
