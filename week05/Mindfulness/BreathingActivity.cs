using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Calls the base class constructor with specific name and description
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {
    }

    // Override the Run method to implement the specific Breathing logic
    public override void Run()
    {
        ShowStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Breathe in...
            if (DateTime.Now < endTime)
            {
                Console.Write("\nBreathe in...");
                ShowCountdown(4); // Pause for 4 seconds
                Console.Write(" \b\r"); // Clear line
            }

            // Breathe out...
            if (DateTime.Now < endTime)
            {
                Console.Write("Breathe out...");
                ShowCountdown(6); // Pause for 6 seconds
                Console.Write(" \b\r"); // Clear line
            }
        }

        ShowEndingMessage();
    }
}