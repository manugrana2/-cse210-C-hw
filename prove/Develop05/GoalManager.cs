using System;
using System.Collections.Generic;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        //Load goals from file
        LoadGoalsFromFile();
        // Interact with user through console commands
        while (true)
        {
            SaveGoalsToFile();
            Console.ForegroundColor = ConsoleColor.White; // Set the text color to white
            Console.WriteLine("1. Display player info");
            Console.WriteLine("2. List goal names");
            Console.WriteLine("3. List goal details");
            Console.WriteLine("4. Create goal");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoalsToFile();
                    return;
                default:
                    blinkText("Invalid Choice, try again!", true);
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.Clear();
        blinkText($"Player score: {_score}", false);
    }

    public void ListGoalNames()
    {
        Console.Clear();
        if (_goals.Count < 1)
        {
            blinkText("There are not goals to display", true);
            return;
        }
        Console.WriteLine("------ List of Goals ------ ");
        int i = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine(i+". " + goal.getShortName());
            i++;
        }
        Console.WriteLine("----------- END ----------- ");
    }

    public void ListGoalDetails()
    {
        Console.Clear();
        if (_goals.Count < 1)
        {
            blinkText("There are not goals to display", true);
            return;
        }
        int i = 1;
        Console.WriteLine("------ List of Goals ------ ");
        foreach (var goal in _goals)
        {
            Console.WriteLine(i.ToString() + ". " + goal.GetDetailsString());
        }
        Console.WriteLine("----------- END ----------- ");
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("Enter goal type: ");
        var type = Console.ReadLine();
        if (type != "1" && type != "2" && type != "3")
        {
            blinkText("Invalid goal type, try again", true);
            return;
        }

        Console.Write("Enter goal name: ");
        var name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        var description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points))
        {
            blinkText("Invalid goal points, it should be a number", true);

            return;
        }

        Goal goal = null;
        switch (type.ToLower())
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target: ");
                var target = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus: ");
                var bonus = int.Parse(Console.ReadLine());

                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                blinkText("Invalid type, goal not created", true);
                return;
        }

        _goals.Add(goal);
        Console.Clear();
    }

    public void RecordEvent()
    {
        if (_goals.Count < 1)
        {
            blinkText("You can not register a event.\nFirst create at least one goal", true);
            return;
        }
        ListGoalDetails();
        Console.Write("\nType the number of the goal you want to add an event for: ");
        int number;
        if (!int.TryParse(Console.ReadLine(), out number))
        {
            blinkText("Invalid input, not a number", true);

            return;
        }
        if (number - 1 < 0 || number - 1 > _goals.Count - 1)
        {
            blinkText("Goal not found", true);
            return;
        }
        var goal = _goals[number - 1];
        _score += goal.RecordEvent();
    }
    public void SaveGoalsToFile()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string targetFolder = Path.Combine(documentsPath, "Goal Tracker");
        string filename = Path.Combine(targetFolder, "saved_goals.txt");

        if (!Directory.Exists(targetFolder))
        {
            Directory.CreateDirectory(targetFolder);
        }
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                file.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoalsFromFile()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string targetFolder = Path.Combine(documentsPath, "Goal Tracker");
        string filename = Path.Combine(targetFolder, "saved_goals.txt");

        if (!File.Exists(filename))
        {
            return;
        }

        using (StreamReader file = new StreamReader(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var details = line.Split(':');
                Goal goal = null;

                switch (details[0])
                {
                    case "SimpleGoal":
                        goal = SimpleGoal.CreateFromRepresentation(details[1]);
                        break;

                    case "EternalGoal":
                        goal = EternalGoal.CreateFromRepresentation(details[1]);
                        break;

                    case "ChecklistGoal":
                        goal = ChecklistGoal.CreateFromRepresentation(details[1]);
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }

    public void blinkText(string text, bool error)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(350);
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Clear();
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(350);
            Console.Clear();
        }
        Console.ResetColor();
    }
}
