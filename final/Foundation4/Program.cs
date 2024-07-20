using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create the activities
        Activity running = new Running("03 Nov 2022", 30, 4.8);
        Activity cycling = new Cycling("04 Nov 2022", 45, 20.0);
        Activity swimming = new Swimming("05 Nov 2022", 25, 20);

        // Store the list of activities
        Console.Clear();
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display activity summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
