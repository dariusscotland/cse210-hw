using System;

public abstract class Activity
{
    // Private member variables
    private DateTime _date;
    private int _minutes;

    // Base constructor for all activities
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();   

    public virtual string GetSummary()
    {
        string name = GetType().Name;
        
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string dateString = _date.ToString("dd MMM yyyy");
        
        return $"{dateString} {name} ({_minutes} min): " +
               $"Distance {distance:F2} km, " +
               $"Speed: {speed:F2} kph, " +
               $"Pace: {pace:F2} min per km";
    }
}