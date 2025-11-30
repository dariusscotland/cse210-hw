public class EternalGoal : Goal
{
    // Standard constructor
    public EternalGoal(string name, string description, int points, bool isBonusGoal = false) : base(name, description, points, isBonusGoal)
    {
    }

    // Load constructor
    public EternalGoal(string dataString) : base(dataString)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_isBonusGoal}";
    }
}