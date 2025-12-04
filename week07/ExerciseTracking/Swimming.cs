using System;

public class Swimming : Activity
{
    // Private unique attribute
    private int _laps; 

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0; 
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (GetMinutes() == 0) return 0;
        return (distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0;
        return GetMinutes() / distance;
    }
}