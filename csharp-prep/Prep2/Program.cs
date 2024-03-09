using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?");
        string grade = Console.ReadLine();

        int gradePercentage = int.Parse(grade);

        int passingGrade = 70;

        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int sign = gradePercentage % 10;

        if (letter != "A" && letter != "F")
        {
          if (sign >= 7)
          {
            letter += "+";
          }
          else if (sign <= 3)
          {
            letter += "-";
          }
        }

        Console.WriteLine($"Your letter grade is {letter}.");
        
        if (gradePercentage >= passingGrade)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("You failed. Try harder next time.");
        }
    }
}