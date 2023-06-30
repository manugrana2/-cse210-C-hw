public class ListingActivity : Activity
{
    public ListingActivity()
    {
        _name = "Listing Activity";
        _infoMsg = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }
    public void Start()
    {
        Console.WriteLine("List as many responses to the following Prompt:");
        List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Create a new Random instance
        Random random = new Random();

        // Select a random question from the list
        int randomIndex = random.Next(prompts.Count);
        string randomPrompt = prompts[randomIndex];

        // Print the random question
        Console.WriteLine($"\n--- {randomPrompt} ---");
        Thread.Sleep(3000);
        Console.Write("You may begin in... ");
        Thread.Sleep(4000);
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
        Console.Write("\bNow\n");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds((int)getTime());
        DateTime currentTime = DateTime.Now;
        while (DateTime.Now < futureTime)
        {
            Console.Write(">");
            Console.ReadLine();
        }

    }

}
