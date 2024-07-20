// I added a new goal type "NegativeGoal", where users lose points for bad habits.
//  Added a DisplayCelebrationEffect method to display celebratory effect when a goal is completed.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
