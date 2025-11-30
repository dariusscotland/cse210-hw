using System;

public class Rectangle : Shape
{
    // Private member variables for length and width
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override the GetArea() method
    public override double GetArea()
    {
        return _length * _width;
    }
}