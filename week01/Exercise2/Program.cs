using System;

class Program
{
    static void Main(string[] args)
    {
        

        Console.WriteLine("Welcome to the Grade Calculator!");
        Console.WriteLine("--------------------------------");
        
        Console.Write("What is your grade percentage (e.g., 85)? ");
        
        
        string input = Console.ReadLine();
        
        
        if (!int.TryParse(input, out int percent))
        {
            Console.WriteLine("Invalid input. Please enter a whole number.");
            return;
        }

        string letter = "";
        string sign = "";
        
        
        
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        
        
        if (percent >= 60 && percent <= 99) 
        {
            int lastDigit = percent % 10; 

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        
        
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        
        
        
        if (letter == "F")
        {
            sign = "";
        }

        
        Console.WriteLine($"\nYour letter grade is: {letter}{sign}");

        

        
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard! You'll get it next time.");
        }
    }
}