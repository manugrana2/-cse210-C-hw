public class Journal
{
    private List<Entry> _entries;
    private List<Entry> _fromFile;

    public Journal()
    {
        _entries = new List<Entry>();
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(documentsPath, "Journal.csv");
        LoadFromFile(filePath);
        _entries =  _fromFile;
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Question: {entry._promptText}");
            Console.WriteLine($"Content: {entry._entryText}");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
        }
    }

    public void SaveToFile(string file = "Journal.csv")
    {
        CsvFileManager fileManager = new CsvFileManager(file);
        if (_entries.Count < 1)
        {
            Console.WriteLine("**Write at least one entry before saving to the file**");
        }
        foreach (Entry entry in _entries)
        {
            string[] row = { entry._date, entry._promptText, entry._entryText };
            fileManager.AddRowToCsv(row);
        }

    }

    public void LoadFromFile(string file = "Journal.csv")
    {
        CsvFileManager fileManager = new CsvFileManager(file);
        List<string[]> entries = fileManager.GetAllRowsFromCsv();
        Console.WriteLine($"Trying to load entries for {file}:");
        Console.WriteLine($"Expecting file format {{Date, Question, Entry_Text}}");
        if (entries.Count < 1)
        {
            Console.WriteLine("It seems the file doesn't exist or it's empty");
        }
        List<Entry> loadedEntries = new List<Entry>();
        foreach (string[] entry in entries)
        {
            Entry loadedEntry = new Entry(entry[0], entry[1], entry[2]);
            loadedEntries.Add(loadedEntry);
        }
        _fromFile = loadedEntries;
        foreach (var entry in loadedEntries)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Question: {entry._promptText}");
            Console.WriteLine($"Content: {entry._entryText}");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
        }
    }

}