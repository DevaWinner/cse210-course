using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            return $"{name}";
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string number = Console.ReadLine();
            int favoriteNumber = int.Parse(number);

            return favoriteNumber;
        }

        static int SquareNumber(int favoriteNumber)
        {
            int squaredNumber = favoriteNumber * favoriteNumber;

            return squaredNumber;
        }

        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        }

        DisplayMessage();
        
        string name = PromptUserName();

        int favoriteNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber);
    }
}