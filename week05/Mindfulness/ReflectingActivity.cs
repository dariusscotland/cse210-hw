using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    // Master lists (private for encapsulation)
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _unusedPrompts;
    private List<string> _unusedQuestions;
    
    private Random _random = new Random();

    // Constructor
    public ReflectingActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    )
    {
        // Copy master lists into temporary lists at object creation
        _unusedPrompts = new List<string>(_prompts);
        _unusedQuestions = new List<string>(_questions);
    }

    public override void Run()
    {
        ShowStartingMessage();

        // 1. Display initial prompt
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("\nWhen you have thought about this experience, press Enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        // 2. Loop through questions for the duration
        DisplayQuestions();

        ShowEndingMessage();
    }

    // Ensures no repetition of prompts
    private string GetRandomPrompt()
    {
        // Refill list if all prompts have been used
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }
        
        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index); // Remove the used prompt
        
        return prompt;
    }

    // Loops, ensuring no repetition of questions
    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int reflectionTimePerQuestion = 8; // Time to pause for each question

        while (DateTime.Now < endTime)
        {
            // Refill list if all questions have been used
            if (_unusedQuestions.Count == 0)
            {
                _unusedQuestions = new List<string>(_questions);
            }

            int index = _random.Next(_unusedQuestions.Count);
            string question = _unusedQuestions[index];
            _unusedQuestions.RemoveAt(index); // Remove the used question

            Console.Write($"\n> {question} ");
            
            // The spinner pauses for a set time, contributing to the total duration.
            ShowSpinner(reflectionTimePerQuestion); 
            Console.Write(" \b\r"); 
        }
    }
}