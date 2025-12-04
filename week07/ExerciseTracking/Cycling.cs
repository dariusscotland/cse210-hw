using System;

public class Cycling : Activity
{
    // Private unique attribute
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * GetMinutes();
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        if (_speed == 0) return 0; 
        return 60 / _speed;
    }
}