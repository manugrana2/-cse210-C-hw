public class PromptGenerator
{
    private List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "What is something new that you learned today?",
            "Describe a moment of kindness that you experienced or witnessed today.",
            "What was a challenge you faced today and how did you overcome it?",
            "Reflect on a decision you made today and its impact on your day.",
            "Write about a book, movie, or song that made an impression on you recently.",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        random = new Random();
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
