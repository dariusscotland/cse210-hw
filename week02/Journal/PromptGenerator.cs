using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is one thing I learned today?", 
            "Describe a moment that made me laugh today." 
        };
    }

    // Method to get a random prompt
    public string GetRandomPrompt()
    {
        // Use a Random object to select a prompt
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
}