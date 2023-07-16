
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        // Once the event is recorded, mark the simple goal as complete
        _isComplete = true;

        // Returns the points associated with the goal as it's now completed
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} - {_description}";
    }
     public override string GetStringRepresentation()
    {
        // return a string that includes the type of the goal and all the necessary details
        return $"SimpleGoal:{ShortName},{Description},{PointValue},{_timesCompleted},{_isComplete}";
    }

    public static SimpleGoal CreateFromRepresentation(string representation)
    {
        // split the string to get the details
        var details = representation.Split(',');

        // create a new SimpleGoal object and set all the values
        SimpleGoal goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
        goal._timesCompleted = int.Parse(details[3]);
        goal._isComplete = bool.Parse(details[4]);

        // return the created goal
        return goal;
    }
}


