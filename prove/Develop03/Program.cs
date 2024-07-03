// I implemented a library of scriptures rather than a single one. 
// I implemented a menu to help users choose scriptures from the library to memorize.
// I implemented multiple console clearing method to handle IDEs that `Console.Clear();` doesn't work in.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the scripture library
        var library = new ScriptureLibrary();

        // Add scriptures to the library
        library.AddScripture(new Reference("Proverbs", 3, 5, 6),
            "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        library.AddScripture(new Reference("John", 3, 16),
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        library.AddScripture(new Reference("Philippians", 4, 13),
            "I can do all this through him who gives me strength.");
        library.AddScripture(new Reference("2 Nephi", 2, 25),
            "Adam fell that men might be; and men are, that they might have joy.");
        library.AddScripture(new Reference("Alma", 32, 21),
            "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");
        library.AddScripture(new Reference("Ether", 12, 27),
            "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them.");
        library.AddScripture(new Reference("Moroni", 10, 4, 5),
            "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. And by the power of the Holy Ghost ye may know the truth of all things.");
        library.AddScripture(new Reference("D&C", 4, 2),
            "Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day.");
        library.AddScripture(new Reference("D&C", 6, 36),
            "Look unto me in every thought; doubt not, fear not.");
        library.AddScripture(new Reference("D&C", 19, 23),
            "Learn of me, and listen to my words; walk in the meekness of my Spirit, and you shall have peace in me.");
        library.AddScripture(new Reference("D&C", 88, 123),
            "See that ye love one another; cease to be covetous; learn to impart one to another as the gospel requires.");

        bool continueProgram = true;

        while (continueProgram)
        {
            ClearConsole();
            DisplayMenu(library);

            var choice = Console.ReadLine()?.ToLower();
            if (choice == "quit")
            {
                break;
            }

            if (int.TryParse(choice, out int index) && index > 0 && index <= library.GetScriptureCount())
            {
                var scripture = library.GetScriptureByIndex(index - 1);

                if (scripture.IsCompletelyHidden())
                {
                    scripture.ResetWords();
                }

                while (true)
                {
                    ClearConsole();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
                    var input = Console.ReadLine();
                    
                    if (input?.ToLower() == "quit")
                    {
                        return;
                    }

                    scripture.HideRandomWords(3);

                    if (scripture.IsCompletelyHidden())
                    {
                        ClearConsole();
                        Console.WriteLine("Congratulations! You've memorized the scripture.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid number from the menu.");
            }
        }
    }

    static void DisplayMenu(ScriptureLibrary library)
    {
        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < library.GetScriptureCount(); i++)
        {
            var scripture = library.GetScriptureByIndex(i);
            Console.WriteLine($"{i + 1}. {scripture.GetReferenceText()}");
        }
        Console.WriteLine("\nEnter the number of the scripture you want to memorize or type 'quit' to exit:");
    }

    static void ClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            try
            {
                Console.Write("\u001b[2J");
                Console.Write("\u001b[H");
            }
            catch (IOException)
            {
                try
                {
                    for (int i = 0; i < Console.WindowHeight; i++)
                    {
                        Console.WriteLine();
                    }
                }
                catch (IOException)
                {
                    // Ignoring any IOExceptions as per your requirement
                }
            }
        }
    }
}
