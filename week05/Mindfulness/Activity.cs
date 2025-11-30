using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

public abstract class Activity
{
    // Attributes (private/protected for encapsulation)
    private string _activityName;
    private string _description;
    protected int _duration; 

    // Constructor
    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
        _duration = 0; 
    }

    // Must be implemented by all derived classes
    public abstract void Run();

    // Displays the starting messages and sets duration
    protected void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        
        // Basic input validation
        if (int.TryParse(input, out int duration))
        {
            _duration = duration;
        }
        else
        {
            Console.WriteLine("Invalid input. Setting duration to 30 seconds.");
            _duration = 30;
        }

        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); // Pause for 5 seconds before starting the activity
    }

    // Displays the ending messages AND logs the activity
    protected void ShowEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done! You have done a good job!");
        ShowSpinner(4); // Pause with a spinner

        Console.WriteLine();
        Console.WriteLine($"You have completed the {_activityName} for {_duration} seconds.");
        ShowSpinner(5); // Pause before returning to the menu

        LogActivity();
    }

    private void LogActivity()
    {
        try
        {
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {_activityName} - Duration: {_duration} seconds\n";
            File.AppendAllText("activity_log.txt", logEntry); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[Error] Could not write to log file: {ex.Message}");
        }
    }

    // Displays a spinner animation
    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(250); 
            Console.Write("\b"); 

            i++;
            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
        Console.Write(" \b"); 
    }

    // Displays a countdown timer
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            for (int j = 0; j < i.ToString().Length; j++)
            {
                 Console.Write("\b"); 
            }
        }
    }
}