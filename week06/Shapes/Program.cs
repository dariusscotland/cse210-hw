using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // --- Testing Individual Classes ---
        Console.WriteLine("## 🧪 Individual Class Testing ##");

        // Test Square
        Square redSquare = new Square("Red", 5.0);
        Console.WriteLine($"Square Test: Color is {redSquare.GetColor()}, Area is {redSquare.GetArea():F2}"); // Expected Area: 25.00
        redSquare.SetColor("Crimson");
        Console.WriteLine($"Updated Color: {redSquare.GetColor()}");
        Console.WriteLine("-----------------------------");

        // Test Rectangle
        Rectangle blueRectangle = new Rectangle("Blue", 4.0, 6.5);
        Console.WriteLine($"Rectangle Test: Color is {blueRectangle.GetColor()}, Area is {blueRectangle.GetArea():F2}"); // Expected Area: 26.00
        Console.WriteLine("-----------------------------");

        // Test Circle
        Circle greenCircle = new Circle("Green", 3.0);
        Console.WriteLine($"Circle Test: Color is {greenCircle.GetColor()}, Area is {greenCircle.GetArea():F2}"); // Expected Area: ~28.27
        Console.WriteLine("-----------------------------");


        Console.WriteLine("\n## 🖼️ Polymorphism Demonstration ##");

        // 1. Create a List<Shape>
        List<Shape> shapes = new List<Shape>();

        // 2. Add different derived types to the list
        shapes.Add(redSquare);
        shapes.Add(blueRectangle);
        shapes.Add(greenCircle);
        shapes.Add(new Square("Yellow", 8.0));
        shapes.Add(new Rectangle("Orange", 10.0, 2.5));
        shapes.Add(new Circle("Purple", 7.0));

        // 3. Iterate through the list and display color and area
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"- **Type:** {shape.GetType().Name}, **Color:** {shape.GetColor()}, **Area:** {shape.GetArea():F2}");
        }
    }
}