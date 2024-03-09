using System;

class Program
{
  static void Main(string[] args)
  {
    Random random = new();
    string playAgain;

    do
    {
      int magicNumber = random.Next(1, 100);

      Console.Write("What is your guess?");
      string guess = Console.ReadLine();
      int guessInt = int.Parse(guess);

      int attempts = 1;

      while (guessInt != magicNumber)
      {
        if (guessInt < magicNumber)
        {
          Console.WriteLine("Higher");
        }
        else
        {
          Console.WriteLine("Lower");
        }

        Console.Write("What is your guess? ");
        guess = Console.ReadLine();
        guessInt = int.Parse(guess);
        attempts++;
      }

      Console.WriteLine("Congratulations! You guessed the number in " + attempts + " attempts.");

      Console.Write("Do you want to play again? (yes/no) ");
      playAgain = Console.ReadLine().ToLower();

    } while (playAgain == "yes");
  }
}