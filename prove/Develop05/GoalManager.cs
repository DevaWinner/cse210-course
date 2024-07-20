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
            DisplayAppName();
            Console.WriteLine($"Current Score: {_score}\n");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit");
            Console.Write("\nEnter your choice: ");
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
                    Console.WriteLine("\nInvalid option. Please try again.");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private void DisplayAppName()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("   Eternal Quest Goal Tracker!");
        Console.WriteLine("=================================\n");
    }

    private void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public void ListGoals()
    {
        Console.Clear();
        DisplayAppName();

        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals found.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        PressAnyKeyToContinue();
    }

    public void CreateGoal()
    {
        Console.Clear();
        DisplayAppName();

        try
        {
            Console.WriteLine("Select the type of goal to create:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            Console.Write("\nEnter goal name: ");
            string name = Console.ReadLine();
            Console.Write("\nEnter goal description: ");
            string description = Console.ReadLine();
            Console.Write("\nEnter goal points: ");
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
                    Console.Write("\nEnter goal target: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("\nEnter goal bonus: ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("\nInvalid goal type. Please try again.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("\nInvalid input. Please enter a valid number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred: {ex.Message}");
        }

        PressAnyKeyToContinue();
    }

    public void RecordEvent()
    {
        while (true)
        {
            Console.Clear();
            DisplayAppName();

            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                PressAnyKeyToContinue();
                return;
            }

            try
            {
                Console.WriteLine("Select the goal to record an event for:");
                List<int> incompleteGoalIndices = new List<int>();

                for (int i = 0; i < _goals.Count; i++)
                {
                    if (!_goals[i].IsComplete())
                    {
                        Console.WriteLine($"  {incompleteGoalIndices.Count + 1}. {_goals[i].GetDetailsString()}");
                        incompleteGoalIndices.Add(i);
                    }
                }

                if (incompleteGoalIndices.Count == 0)
                {
                    Console.WriteLine("No incomplete goals available.");
                    PressAnyKeyToContinue();
                    return;
                }

                Console.Write("\nEnter the goal index to record event: ");
                int goalIndex = int.Parse(Console.ReadLine()) - 1;

                if (goalIndex < 0 || goalIndex >= incompleteGoalIndices.Count)
                {
                    Console.WriteLine("Invalid goal index.");
                    PressAnyKeyToContinue();
                    continue;
                }

                Goal goal = _goals[incompleteGoalIndices[goalIndex]];
                goal.RecordEvent();
                int pointsEarned = goal.Points;

                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    pointsEarned += checklistGoal.Bonus;
                    _score += pointsEarned;
                    Console.WriteLine($"\nGoal completed! You earned {pointsEarned} points.");
                }
                else
                {
                    _score += pointsEarned;
                    Console.WriteLine($"\nCongratulations! You earned {pointsEarned} points for recording this event.");
                }

                PressAnyKeyToContinue();
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                PressAnyKeyToContinue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                PressAnyKeyToContinue();
            }
        }
    }

    public void SaveGoals()
    {
        Console.Clear();
        DisplayAppName();

        Console.Write("Enter file name to save: ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("\nGoals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        PressAnyKeyToContinue();
    }

    public void LoadGoals()
    {
        Console.Clear();
        DisplayAppName();

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

        PressAnyKeyToContinue();
    }
}
