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
        // Interact with user through console commands
        while (true)
        {
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
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.ShortName);
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal type (simple, eternal, checklist): ");
        var type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        var name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        var description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        var points = int.Parse(Console.ReadLine());

        Goal goal = null;
        switch (type.ToLower())
        {
            case "simple":
                goal = new SimpleGoal(name, description, points);
                break;
            case "eternal":
                goal = new EternalGoal(name, description, points);
                break;
            case "checklist":
                Console.Write("Enter target: ");
                var target = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus: ");
                var bonus = int.Parse(Console.ReadLine());

                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid type, goal not created.");
                return;
        }

        _goals.Add(goal);
    }

    public void RecordEvent()
    {
        Console.Write("Enter goal name: ");
        var name = Console.ReadLine();
        var goal = _goals.FirstOrDefault(g => g.ShortName == name);
        if (goal == null)
        {
            Console.WriteLine("Goal not found.");
            return;
        }

        _score += goal.RecordEvent();
    }
    public void SaveGoalsToFile(string filename)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                file.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoalsFromFile(string filename)
    {
        _goals.Clear();

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
}
