public class NegativeGoal : Goal
{
    // Standard constructor
    public NegativeGoal(string name, string description, int points, bool isBonusGoal = false) : base(name, description, points, isBonusGoal)
    {
        
    }

    // Load constructor
    public NegativeGoal(string dataString) : base(dataString)
    {
        
    }

    // Overrides RecordEvent
    public override int RecordEvent()
    {
        Console.WriteLine($"\n--- PENALTY! You lost {_points} points for failing {_shortName}. ---");
        return -_points;
    }

    // Overrides GetDetailsString to visually indicate a penalty
    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({_description}) - Penalty: -{_points} points";
    }

    // Overrides GetStringRepresentation for saving
    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{GetName()}|{_description}|{_points}|{_isBonusGoal}";
    }
}