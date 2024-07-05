// I made sure no random prompts/questions are selected until they have all been used at least once in that session.
// I made sure the user can't enter a negative number for the duration of the activity.
// I added StretchingActivity that helps the user relax by guiding them through a series of stretches.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== Welcome to the Mindfulness App ====");
            Console.WriteLine("\nPlease choose an activity:");
            Console.WriteLine("\t1. Breathing Activity");
            Console.WriteLine("\t2. Listing Activity");
            Console.WriteLine("\t3. Reflecting Activity");
            Console.WriteLine("\t4. Stretching Activity");
            Console.WriteLine("\t5. Exit");
            Console.Write("\nSelect a choice from the menu: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number from 1 to 5.");
                Console.ReadKey();
                continue;
            }

            Activity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ListingActivity();
                    break;
                case 3:
                    activity = new ReflectingActivity();
                    break;
                case 4:
                    activity = new StretchingActivity();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    continue;
            }

            activity.Run();
        }
    }
}
