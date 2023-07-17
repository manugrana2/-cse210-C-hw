public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        // Increase the number of times the event has been recorded
        _timesRecorded++;

        // Returns the points associated with each recording of the event
        return _points;
    }

    public override bool IsComplete()
    {
        // An eternal goal is never completed
        return false;
    }

    public override string GetDetailsString()
    {
        // For eternal goals, we also show the number of times the event has been recorded
        return $"[ ] {_shortName} - {_description}, Times Recorded: {_timesRecorded}";
    }
      public override string GetStringRepresentation()
    {
        // return a string that includes the type of the goal and all the necessary details
        return $"EternalGoal:{_shortName},{_description},{_points},{_timesRecorded}";
    }

    public static EternalGoal CreateFromRepresentation(string representation)
    {
        // split the string to get the details
        var details = representation.Split(',');

        // create a new EternalGoal object and set all the values
        EternalGoal goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
        goal._timesRecorded = int.Parse(details[3]);

        // return the created goal
        return goal;
    }
}
