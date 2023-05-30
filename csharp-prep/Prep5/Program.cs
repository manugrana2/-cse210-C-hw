using System;

class Program
{
    static void Main(string[] args)
    {
        // Displays the message, "Welcome to the Program!"
        static string DisplayWelcome()
        {
            return ("Welcome to the Program!");
        }
        // Asks for and returns the user's name (as a string)
        static string PromptUserName()
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            return (name);
        }
        // Asks for and returns the user's favorite number (as an integer)
        static int PromptUserNumber()
        {
            Console.WriteLine("Please enter your favorite number:");
            int favNumber;
            if (int.TryParse(Console.ReadLine(), out favNumber))
            {
                return (favNumber);
            }
            else
            {
                Console.WriteLine("That's not a integer number, we will use 0 instead ;).");
                return (favNumber);
            }

        }
        // Accepts an integer as a parameter and returns that number squared (as an integer)
        static int SquareNumber(int number){
            return(number*number);
        }
        //Accepts the user's name and the squared number and displays them.
        static void DisplayResult(string name, int squaredNum){
            Console.WriteLine($"{name}, the square of your number is {squaredNum}");
        }
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaredNum = SquareNumber(number);
        DisplayResult(name, squaredNum);
    }
}