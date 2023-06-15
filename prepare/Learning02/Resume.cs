public class Resume{
    public string _name {get;set;}
    public List<Job> _Jobs {get; set;}
    public void Display(){
        Console.WriteLine($"Name: {this._name}");
        Console.WriteLine($"Jobs:");
        foreach(Job job in this._Jobs){
            job.Display();
        }
    }


}