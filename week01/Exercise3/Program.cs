using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1; 
            int guessCount = 0; 

            Console.WriteLine("\n==================================");
            Console.WriteLine("    Welcome to Guess My Number!   ");
            Console.WriteLine("I have chosen a number between 1 and 100.");
            Console.WriteLine("==================================");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessString = Console.ReadLine();
                
                if (!int.TryParse(guessString, out guess))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    continue; 
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine("You guessed it!");
            
            Console.WriteLine($"It took you {guessCount} guesses to find the magic number!");

            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("\nThanks for playing! Goodbye.");
    }
}