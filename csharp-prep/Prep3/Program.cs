using System;

class Program
{
    public static void StartGame()
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        int guesses = 0;
        bool guessed = false;
        while (guessed == false)
        {
            Console.WriteLine("What is your guess (1-100)?");
            string guess = Console.ReadLine();
            int guessNum;
            if (int.TryParse(guess, out guessNum))
            {
                if (guessNum == number)
                {
                    Console.WriteLine("You guessed it!");
                    guessed = true;
                }
                else if (guessNum < number)
                {
                    Console.WriteLine("Higher");
                    guesses++;
                }
                else{
                    Console.WriteLine("Lower");
                    guesses++;
                }
            }

        }
        Console.WriteLine($"Congrats!, it took you {guesses} guesses");

    }
    static void Main(string[] args)
    {
        StartGame();
        Console.WriteLine("---------------------------------------");
        bool finish = false;
        while(finish == false){
            Console.WriteLine("Do you want to play again? Write yes or no.");
            string response = Console.ReadLine();
            if(response == "yes"){
                StartGame();
            }else if (response == "no"){
                Console.WriteLine("Thanks for playing. Finishing the program, bye!");
                finish = true;
            }
        }

    }
}