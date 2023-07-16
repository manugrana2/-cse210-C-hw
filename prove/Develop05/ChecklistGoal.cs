public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        // If target is reached, return points with bonus, otherwise return just the points
        if (_amountCompleted >= _target)
        {
            return _points + _bonus;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} - {_description}, Completed {_amountCompleted}/{_target} times";
    }
        public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_ShortName},{_Description},{_PointValue},{_timesCompleted},{_timesRequired},{_bonusForCompletion}";
    }

    public static ChecklistGoal CreateFromRepresentation(string representation)
    {
        var details = representation.Split(',');
        ChecklistGoal goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
        goal._timesCompleted = int.Parse(details[3]);
        return goal;
    }
}
