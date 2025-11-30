using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points; 
    protected bool _isBonusGoal; 

    // Constructor for creating new goals
    public Goal(string name, string description, int points, bool isBonusGoal = false)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isBonusGoal = isBonusGoal;
    }

    // Constructor for loading goals from file
    public Goal(string dataString)
    {
        string[] parts = dataString.Split('|');
        _shortName = parts[1];
        _description = parts[2];
        _points = int.Parse(parts[3]);
        _isBonusGoal = bool.Parse(parts[4]);
    }

    // Public getters (Abstraction)
    public string GetName()
    {
        return _shortName;
    }
    
    public string GetDescription()
    {
        return _description;
    }

    // All derived goals must implement these.
    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        string bonusTag = _isBonusGoal ? " ✨" : "";
        return $"{status} {_shortName} ({_description}){bonusTag}";
    }

    public virtual bool IsComplete()
    {
        return false;
    }
}