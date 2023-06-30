public class ReflectionActivity : Activity
{
    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _infoMsg = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }
    public void Start()
    {
        Console.WriteLine("Consider the following Prompt:");
        List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // Create a new Random instance
        Random random = new Random();

        // Select a random question from the list
        int randomIndex = random.Next(prompts.Count);
        string randomPrompt = prompts[randomIndex];

        // Print the random question
        Console.WriteLine($"\n--- {randomPrompt} ---");
        Console.WriteLine($"\nWhen you have something in mind hit Enter to Continue");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to that experience.");
        Console.Write("You may begin in... ");
        Console.Write("\b5");
        Thread.Sleep(1000);
        Console.Write("\b4");
        Thread.Sleep(1000);
        Console.Write("\b3");
        Thread.Sleep(1000);
        Console.Write("\b2");
        Thread.Sleep(1000);
        Console.Write("\b1");
        Thread.Sleep(1000);
        Console.Write("\b ");
        Console.Clear();
        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Create a new Random instance
        Random randomQ = new Random();

        for (int i = 0; i < getTime() / 30; i++)
        {
            if (questions.Count > 0)
            {
                // Select a random question from the list
                int index = randomQ.Next(questions.Count);
                string randomQuestion = questions[index];

                // Print the random question
                Console.WriteLine($"\b> {randomQuestion}");
                Loader loader = new Loader();
                loader.Start();
                Thread.Sleep(30000);
                loader.Stop();
                Console.Write("\b ");


                // Remove the asked question from the list
                questions.RemoveAt(index);
            }
        }

    }

}