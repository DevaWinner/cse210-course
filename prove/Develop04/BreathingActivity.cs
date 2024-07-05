using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            if (stopwatch.Elapsed.TotalSeconds >= _duration) break;

            Console.Write("Now breathe out... ");
            ShowCountDown(6);
        }

        stopwatch.Stop();
        DisplayEndingMessage();
    }
}
