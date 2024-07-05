using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity\n");
        Console.WriteLine(_description);
        Console.Write("\nPlease specify the session duration in seconds: ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number for the duration: ");
        }
        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(5);
        Console.WriteLine("\n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nActivity Complete!!");
        ShowSpinner(5);
        Console.WriteLine($"\nYou have completed the {_name} Activity for {_duration} seconds.");
        ShowSpinner(4);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.Write(" ");
        Console.Write("\b");
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - (i.ToString().Length + 1), Console.CursorTop);
            Console.Write(new string(' ', i.ToString().Length + 1));
            Console.SetCursorPosition(Console.CursorLeft - (i.ToString().Length + 1), Console.CursorTop);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}
