using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    // Attributes for Prompts/Count
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    // Constructor
    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    )
    {
    }

    // Override the Run method to implement the specific Listing logic
    public override void Run()
    {
        ShowStartingMessage();
        
        // 1. Display initial prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        // 2. Collect user items until the duration is reached
        int itemCount = GetListFromUser();

        // 3. Display final count
        Console.WriteLine($"\nYou listed {itemCount} items!");
        
        ShowEndingMessage();
    }

    // Get a random listing prompt
    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Collects items from the user until the timer runs out
    private int GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int itemCount = 0;
        
        Console.WriteLine(); 

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            
            string item = Console.ReadLine(); 
            
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }
        return itemCount;
    }
}