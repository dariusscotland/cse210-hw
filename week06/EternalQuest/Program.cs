/*
=================================================
EXCEEDING REQUIREMENTS
=================================================
1. Gamification: Implemented a Player Leveling System.
   - The user starts at Level 1 and gets a 500 point bonus upon leveling up.
   - The points required for the next level increase progressively (1.5x).
   - The current score and progress to the next level are displayed prominently.
   
2. Additional Goal Type: Implemented a 'NegativeGoal'.
   - This goal type imposes a point penalty (subtracted from the score) when an event is recorded. 
   - Example: Penalty for eating fast food.
   
3. Small Cosmetic Addition: Added an optional 'Bonus Goal' flag (✨) to the base Goal class for visual emphasis in the list.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}