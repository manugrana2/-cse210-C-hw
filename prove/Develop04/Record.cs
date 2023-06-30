public class Record
{
    public string Name { get; }
    public double Time { get; }

    public Record(string name, double time)
    {
        Name = name;
        Time = time;
    }
}