using System;

public class Shape
{
    // Private member variable for color
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Public method to get the color (Getter)
    public string GetColor()
    {
        return _color;
    }

    // Public method to set the color (Setter)
    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double GetArea()
    {
        throw new NotImplementedException("Base class GetArea() method must be overridden in derived classes.");
    }
}