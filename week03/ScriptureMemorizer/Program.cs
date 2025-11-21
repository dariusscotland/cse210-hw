using System;

class Program
{
    // --- EXCEEDING REQUIREMENTS NOTE ---
    // The program exceeds core requirements by implementing the stretch challenge:
    // 1. The Scripture.HideRandomWords method only selects words that are *not* already hidden, 
    //    ensuring efficient and progressive memorization.
    // 2. The program is designed to hide a progressive number of words (3-5) each turn,
    //    rather than a fixed amount, to speed up the memorization process.
    // ------------------------------------

    static void Main(string[] args)
    {
        // 1. Instantiate the Scripture object
        // Example with a verse range (Proverbs 3:5-6)
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // Main Memorization Loop
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Clear the console before displaying the updated scripture
            Console.Clear();
            
            // 2. Display the current state of the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // 3. Prompt the user
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            // 4. Hide words if the user pressed Enter
            if (userInput == "")
            {
                // Hide 3 to 5 random, unhidden words (Exceeding requirement)
                int wordsToHide = new Random().Next(3, 6); 
                scripture.HideRandomWords(wordsToHide);
            }
        }

        // Final Display of the completely hidden scripture or exit message
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        if (userInput.ToLower() == "quit")
        {
            Console.WriteLine("\nProgram terminated by user.");
        }
        else
        {
            Console.WriteLine("\nAll words have been hidden. Scripture successfully memorized (on screen!).");
        }
    }
}