using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("From a list of integer numbers this program will compute:");
        Console.WriteLine("the sum, average, smallest positive number and sort them.");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Enter a list of integer numbers, type 0 when finished.");
        bool running = true;
        string input = String.Empty;
        List<int> numbers = new List<int>();
        int number;
        int min = 0;
        while (running == true)
        {
            Console.WriteLine("Enter number (0 to exit):");
            input = Console.ReadLine();
            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ups. That's not an integer number");
                continue;
            }
            else if (number == 0)
            {
                break;
            }
            // Check if the number is the smallest positive number
            if (numbers.Count() == 0 && number > 0)
            {
                min = number;
            }
            else if (number > 0 && number < min)
            {
                min = number;
            }
            // Add the number to the list of numbers
            numbers.Add(number);

        }
        Console.WriteLine($"The sum is: {numbers.Sum()}");
        Console.WriteLine($"The average is: {numbers.Average()}");
        Console.WriteLine($"The smallest positive number is: {min}");
        Console.WriteLine("The sorted list is:");
        // Sort and print the number list
        numbers.Sort();
        foreach (int num in numbers){
            Console.WriteLine(num);
        }

    }
}