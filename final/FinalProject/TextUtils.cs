public static class TextUtils
{
    public static void BlinkText(string text, bool error = true)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(350);
            if (error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Clear();
            Console.WriteLine(text);
            System.Threading.Thread.Sleep(350);
            Console.Clear();
        }
        Console.ResetColor();
    }
}
