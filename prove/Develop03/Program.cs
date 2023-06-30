using System;
/*
This program helps you learn to memorize poems or passages of scripture
Requirements exceeded by letting the user input its own scripture to learn.
*/
class Program
{
    public static List<Word> SplitWords(string text)
    {
        char[] delimiters = new char[] { ' ', '\r', '\n', '\t' }; // Use appropriate delimiters for your context
        string[] word_list = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<Word> wordList = new List<Word>();
        foreach (string word in word_list)
        {
            Word newWord = new Word(word);
            wordList.Add(newWord);
        }
        return wordList;
    }
    static void Main(string[] args)
    {
        bool running = true;
        Console.Clear();
        Console.WriteLine("This program helps you memorize a scripture. Just provide the next information:");
        Console.WriteLine("What is the name of the book?(ex. Psalm)");
        string book = Console.ReadLine();
        Console.WriteLine("What is the chapter of the book?(ex. 4)");
        string chapter = Console.ReadLine();
        Console.WriteLine("What is the verse o range of verses of the book?(ex. 8)");
        string verse = Console.ReadLine();
        Console.WriteLine("What is the text of the scripture?");
        string scripture_text = Console.ReadLine();
        Reference reference = new Reference(book, int.Parse(chapter), verse);
        List<Word> words = SplitWords(scripture_text);
        Scripture scripture = new Scripture(reference, words);
        Console.Clear();
        Console.WriteLine("\n" + scripture.GetDisplayText());
        while (running == true)
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish");
            string input = Console.ReadLine();
            if (input.Contains("quit") || input.Contains("QUIT"))
            {
                running = false;
            }
            else
            {
                int wordsToHide = (int)Math.Ceiling(words.Count / 7.0);
                scripture.HideRandomWords(wordsToHide);
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                if (scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All the words have already been hiden, got to say bye!");
                    running = false;
                }
            }

        }
    }
}
