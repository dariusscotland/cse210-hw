using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    
    // Player Leveling System
    private int _level;
    private int _pointsToNextLevel;
    
    // Constructor initializes the state
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 1000;
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1: CreateGoal(); break;
                    case 2: ListGoalDetails(); break;
                    case 3: RecordEvent(); break;
                    case 4: SaveGoals(); break;
                    case 5: LoadGoals(); break;
                    case 6: break; 
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        // Displays score and level
        Console.WriteLine($"\n=======================================================");
        Console.WriteLine($"Your Current Score: {_score} points");
        Console.WriteLine($"Level {_level}: {_score} / {_pointsToNextLevel} points to next level");
        Console.WriteLine($"=======================================================");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals set yet. Select 'Create New Goal' from the menu.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Uses the goal's specific GetDetailsString()
            Console.WriteLine($" {i + 1}. {_goals[i].GetDetailsString()}"); 
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal");
        Console.Write("Which type of goal would you like to create? ");
        
        if (!int.TryParse(Console.ReadLine(), out int goalType))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal (enter a positive number)? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid point value.");
            return;
        }

        Console.Write("Should this goal be marked as a Bonus Goal? (yes/no): ");
        bool isBonusGoal = Console.ReadLine().ToLower() == "yes";
        
        Goal newGoal = null;
        switch (goalType)
        {
            case 1: 
                newGoal = new SimpleGoal(name, description, points, isBonusGoal);
                break;
            case 2: 
                newGoal = new EternalGoal(name, description, points, isBonusGoal);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus amount for completing it? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus, isBonusGoal);
                break;
            case 4:
                // The points here represent the penalty magnitude
                newGoal = new NegativeGoal(name, description, points, isBonusGoal);
                break;
            default:
                Console.WriteLine("Goal type not recognized.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine($"\nGoal '{name}' created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record events for.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($" {i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            
            // Calls the specific RecordEvent() method
            int pointsEarned = selectedGoal.RecordEvent(); 
            
            _score += pointsEarned;
            
            // Level up check
            CheckLevelUp();

            // Simple confirmation message
            if (pointsEarned > 0)
            {
                Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
            }
            // Penalty message is handled inside NegativeGoal.RecordEvent()
            
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Leveling logic
    private void CheckLevelUp()
    {
        while (_score >= _pointsToNextLevel)
        {
            _level++;
            // Increase the points required for the next level (e.g., 50% more each time)
            _pointsToNextLevel = (int)(_pointsToNextLevel * 1.5); 
            Console.WriteLine($"\n\n🎉 QUEST COMPLETE! You have reached Level {_level}! 🎉");
            // Give a bonus for leveling up
            _score += 500; 
            Console.WriteLine("A Level-Up Bonus of 500 points has been awarded!");
        }
    }
    
    // Save and Load logic uses the GetStringRepresentation() polymorphism

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write score and level info
                writer.WriteLine($"{_score},{_level},{_pointsToNextLevel}");

                foreach (Goal goal in _goals)
                {
                    // Calls the goal's unique GetStringRepresentation()
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals successfully saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nError: File not found at {filename}.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            
            // 1. Load Score/Level Info
            string[] scoreInfo = lines[0].Split(',');
            _score = int.Parse(scoreInfo[0]);
            _level = int.Parse(scoreInfo[1]);
            _pointsToNextLevel = int.Parse(scoreInfo[2]);

            // Clear existing goals and load new ones
            _goals.Clear();

            // 2. Load Goals
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                string type = parts[0];

                Goal loadedGoal = null;
                switch (type)
                {
                    case "SimpleGoal":
                        loadedGoal = new SimpleGoal(line);
                        break;
                    case "EternalGoal":
                        loadedGoal = new EternalGoal(line);
                        break;
                    case "ChecklistGoal":
                        loadedGoal = new ChecklistGoal(line);
                        break;
                    case "NegativeGoal":
                        loadedGoal = new NegativeGoal(line);
                        break;
                }

                if (loadedGoal != null)
                {
                    _goals.Add(loadedGoal);
                }
            }
            Console.WriteLine($"\nGoals successfully loaded from {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
            _goals.Clear(); 
        }
    }
}