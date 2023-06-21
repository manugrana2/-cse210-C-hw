using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wellcome to your Journal Program.");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("This program will automatically load and save your journal to the 'Journal.csv' file in the current filepath");
        Console.WriteLine("------------------------------------------");
        Journal journal = new Journal();
        Console.WriteLine("------------------------------------------");
        bool running = true;
        string message;
        while (running)
        {
            Console.WriteLine("Select what do you want to do now (Write only the number)");
            Console.WriteLine("1. Write a new Entry");
            Console.WriteLine("2. Load Entries from a file");
            Console.WriteLine("3. Save your entries to an specific file");
            Console.WriteLine("4. Exit saving changes");
            Console.WriteLine("0. Exit and discard unsaved changes");
            string selection = Console.ReadLine();
            if (selection == "1")
            {
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("A random question will be generated to help you with your today's entry, after writing it, press enter to save");
                Console.WriteLine("---------------------------------------------------------------");
                PromptGenerator prompt = new PromptGenerator();
                string promptText = prompt.GetRandomPrompt();
                Console.WriteLine(promptText);
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                string entryText = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------------");
                Entry entry = new Entry(currentDate, promptText, entryText);
                journal.AddEntry(entry);
            }
            else if (selection == "2")
            {
                Console.WriteLine("Please write the file path to your previously saved journal file");
                string journalPath = Console.ReadLine();
                journal.LoadFromFile(journalPath);
            }
            else if (selection == "3")
            {
                // Logic for saving entries to a specific file
                Console.WriteLine("Please write the file path to your where you want your current journal file to be saved");
                string saveToFile = Console.ReadLine();
                journal.SaveToFile();
            }
            else if (selection == "4")
            {
                // Logic for exiting and saving changes
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, "Journal.csv");
                journal.SaveToFile(filePath);
                running = false;
                Console.WriteLine("Your list of entries are until now:");
                journal.DisplayAll();
            }
            else if (selection == "0")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid option.");
            }
            Console.WriteLine("Your list of entries are until now:");
            journal.DisplayAll();
        }

    }
}