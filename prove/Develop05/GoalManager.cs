using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"Current Score: {_score}\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
            }
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter goal target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter goal bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record an event.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Select the goal to record an event for:");
        List<int> incompleteGoalIndices = new List<int>();

        for (int i = 0; i < _goals.Count; i++)
        {
            if (!_goals[i].IsComplete())
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
                incompleteGoalIndices.Add(i);
            }
        }

        if (incompleteGoalIndices.Count == 0)
        {
            Console.WriteLine("No incomplete goals available.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter the goal index to record event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (!incompleteGoalIndices.Contains(goalIndex))
        {
            Console.WriteLine("Invalid goal index.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        Goal goal = _goals[goalIndex];
        goal.RecordEvent();
        int pointsEarned = goal.Points;

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            pointsEarned += checklistGoal.Bonus;
            _score += pointsEarned;
            Console.WriteLine($"Goal completed! You earned {pointsEarned} points.");
        }
        else
        {
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points for recording this event.");
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void SaveGoals()
    {
        Console.Write("Enter file name to save: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void LoadGoals()
    {
        Console.Write("Enter file name to load: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
        }
        else
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                _score = int.Parse(lines[0]);
                _goals = new List<Goal>();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(':');
                    string type = parts[0];
                    string data = parts[1];

                    Goal goal = null;
                    switch (type)
                    {
                        case "SimpleGoal":
                            goal = SimpleGoal.FromString(data);
                            break;
                        case "EternalGoal":
                            goal = EternalGoal.FromString(data);
                            break;
                        case "ChecklistGoal":
                            goal = ChecklistGoal.FromString(data);
                            break;
                    }

                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
