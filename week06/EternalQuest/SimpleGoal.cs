public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Standard constructor
    public SimpleGoal(string name, string description, int points, bool isBonusGoal = false) : base(name, description, points, isBonusGoal)
    {
        _isComplete = false;
    }

    // Load constructor
    public SimpleGoal(string dataString) : base(dataString)
    {
        string[] parts = dataString.Split('|');
        _isComplete = bool.Parse(parts[5]);
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetName()}|{_description}|{_points}|{_isBonusGoal}|{_isComplete}";
    }
}