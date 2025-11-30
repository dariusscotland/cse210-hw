public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Standard constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus, bool isBonusGoal = false) : base(name, description, points, isBonusGoal)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Load constructor
    public ChecklistGoal(string dataString) : base(dataString)
    {
        string[] parts = dataString.Split('|');
        _target = int.Parse(parts[5]);
        _bonus = int.Parse(parts[6]);
        _amountCompleted = int.Parse(parts[7]);
    }

    // Overrides RecordEvent
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        
        _amountCompleted++;
        int pointsGained = _points;

        if (IsComplete())
        {
            pointsGained += _bonus;
            Console.WriteLine($"\n*** CONGRATULATIONS! You completed {_shortName} and earned a bonus of {_bonus} points! ***");
        }
        
        return pointsGained;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Overrides GetDetailsString to show progress (e.g., 2/5)
    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        string bonusTag = _isBonusGoal ? " ✨" : "";
        
        return $"{status} {GetName()} ({_description}) -- Completed {_amountCompleted}/{_target} times{bonusTag}";
    }

    // Overrides GetStringRepresentation for saving
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetName()}|{_description}|{_points}|{_isBonusGoal}|{_target}|{_bonus}|{_amountCompleted}";
    }
}