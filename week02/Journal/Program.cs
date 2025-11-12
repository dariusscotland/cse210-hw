using System;
using System.IO; // Required for StreamWriter and File operations

/*
    Exceeding Requirements:
    1. Added two extra prompts to the PromptGenerator class (Total of 7).
    2. Added basic error handling (try-catch blocks) in the Journal class for file operations (FileNotFoundException and general Exception).
*/

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("\nWelcome to the Journal Program!");

        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string choice = "";
        
        while (choice != "5")
        {
            
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(myJournal, promptGenerator);
                    break;
                
                case "2":
                    myJournal.DisplayAll();
                    break;
                
                case "3":
                    LoadJournal(myJournal);
                    break;

                case "4":
                    SaveJournal(myJournal);
                    break;
                
                case "5":
                    break;
                
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    private static void WriteNewEntry(Journal journal, PromptGenerator generator)
    {
        // 1. Get a random prompt
        string randomPrompt = generator.GetRandomPrompt();
        
        Console.WriteLine($"{randomPrompt}");
        Console.Write("> ");
        
        // 2. Get the user's response
        string userResponse = Console.ReadLine();
        
        // 3. Get the current date as a string
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        // 4. Create a new Entry object
        Entry newEntry = new Entry
        {
            Date = dateText,
            PromptText = randomPrompt,
            EntryText = userResponse
        };

        // 5. Add the new entry to the journal
        journal.AddEntry(newEntry);
        
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        Console.WriteLine();
        string filename = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("\nFilename cannot be empty.");
        }
    }

    private static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        Console.WriteLine();
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("\nFilename cannot be empty.");
        }
    }
}