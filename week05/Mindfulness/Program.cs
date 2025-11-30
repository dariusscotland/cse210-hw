using System;

public class Program
{
    /*
    * EXCEEDING REQUIREMENTS:
    * * 1. Persistent Activity Logging: The base Activity class now includes a private method, LogActivity(), 
    * which is called by ShowEndingMessage(). This method writes the date, activity name, and duration 
    * to an 'activity_log.txt' file, fulfilling the requirement to keep a log.
    * * 2. Preventing Repetition: The ReflectingActivity class now uses temporary lists (_unusedPrompts and 
    * _unusedQuestions) to track items used in the current session. Prompts and questions are removed 
    * upon use, ensuring that no repetition occurs until all items have been cycled through, fulfilling
    * the requirement to cycle through prompts/questions.
    */

    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            Activity currentActivity = null;

            switch (choice)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    break;
                case "2":
                    currentActivity = new ReflectingActivity();
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for practicing mindfulness! Goodbye.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to return to the menu.");
                    Console.ReadLine();
                    continue;
            }

            if (currentActivity != null)
            {
                currentActivity.Run();
            }
        }
    }
}