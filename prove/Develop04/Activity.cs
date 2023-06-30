using System.Text.Json;

public class Activity
{
    private double _time;
    protected string _infoMsg;
    protected string _name;
    static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    static string mindfulnessPath = Path.Combine(documentsPath, ".Mindfulness");
    static string recordsPath = Path.Combine(mindfulnessPath, "records.json");

    public Activity()
    {
        _time = 30;
    }

    protected double getTime()
    {
        return _time;
    }
    public void setTime()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine($"{_infoMsg}");
        Console.Write("\nHow long, in seconds, would your like your session? ");
        string time = Console.ReadLine();
        if (!double.TryParse(time, out _time))
        {
            Console.Write("The value is not valid, a 30 seconds default value will be used");
        }

    }
    public void Ending()
    {
        Console.WriteLine("\nWell done!!");
        Loader loader = new Loader();
        loader.Start();
        Thread.Sleep(3000);
        loader.Stop();
        Console.WriteLine("\b ");
        Console.WriteLine($"You have completed another {_time} seconds of the {_name}");
        loader.Start();
        Thread.Sleep(5000);
        loader.Stop();

        Save();
    }

    public void GetReady()
    {
        Console.Clear();
        Loader loader = new Loader();
        Console.WriteLine("Get Ready...");
        loader.Start();
        Thread.Sleep(4000);
        loader.Stop();
        Console.Write("\b ");
        Console.WriteLine("\n");
    }

    public void Save()
    {

        // Ensure directory exists
        Directory.CreateDirectory(mindfulnessPath);

        // Ensure the file exists
        if (!File.Exists(recordsPath))
        {
            // Initialize it with an empty array if the file does not exist
            File.WriteAllText(recordsPath, "[]");
        }

        // Deserialize the existing data in the file
        string existingJson = File.ReadAllText(recordsPath);
        List<Record> records = JsonSerializer.Deserialize<List<Record>>(existingJson) ?? new List<Record>();

        // Create a new person
        var newRecord = new Record(_name, _time);

        // Add the new person to the existing people
        records.Add(newRecord);

        // Serialize the people list back to a JSON string
        string newJson = JsonSerializer.Serialize(records);
        // Write the new JSON string back to the file
        File.WriteAllText(recordsPath, newJson);
    }
    public void DisplayRecords()
    {
        // Ensure directory exists
        Directory.CreateDirectory(mindfulnessPath);

        // Ensure the file exists
        if (!File.Exists(recordsPath))
        {
            // Initialize it with an empty array if the file does not exist
            File.WriteAllText(recordsPath, "[]");
        }
        // Read the JSON data from the file
        string jsonData = File.ReadAllText(recordsPath);

        // Parse the JSON data
        JsonDocument jsonDoc = JsonDocument.Parse(jsonData);

        // Create a dictionary to accumulate the times for each activity
        Dictionary<string, double> activityTimes = new Dictionary<string, double>();

        // Iterate through the JSON array
        foreach (JsonElement activity in jsonDoc.RootElement.EnumerateArray())
        {
            // Get the name and time of the activity
            string name = activity.GetProperty("Name").GetString();
            double time = activity.GetProperty("Time").GetDouble();

            // Accumulate the time for the activity in the dictionary
            if (activityTimes.ContainsKey(name))
            {
                activityTimes[name] += time;
            }
            else
            {
                activityTimes[name] = time;
            }
        }

        // Display the accumulated times for each activity
        Console.Clear();
        Console.WriteLine("--- List of Records --- \n");
        Console.WriteLine("{0, -30} {1, -10}", "Activity", "Time");
        foreach (KeyValuePair<string, double> pair in activityTimes)
        {
            Console.WriteLine("{0, -30} {1, -10}", pair.Key, pair.Value);
        }
        Console.WriteLine("\n Hit Enter to return to the menu");
        Console.ReadLine();
    }
}