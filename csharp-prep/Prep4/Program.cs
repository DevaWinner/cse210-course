using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int sum;
        double average;
        int max;
        int smallestPositive;

        while (true)
        {
            Console.Write("Enter a list of numbers, type 0 when finished ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                break;
            }

            int number = int.Parse(input);
            numbers.Add(number);
        }

        sum = numbers.Sum();
        average = (double)sum / numbers.Count;
        max = numbers.Max();
        smallestPositive = numbers.Where(n => n > 0).Min();

        numbers.Sort();

        Console.WriteLine($"The sum of the numbers is: {sum}");
        Console.WriteLine($"The average of the numbers is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine($"The numbers sorted are {string.Join(", ", numbers)}");
    }
}