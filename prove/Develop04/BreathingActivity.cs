public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _infoMsg = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    public void Start()
    {
        Console.Clear();
        Loader loader = new Loader();
        Console.WriteLine("Get Ready...");
        loader.Start();
        Thread.Sleep(4000);
        loader.Stop();
        Console.Write("\b ");
        Console.WriteLine("\n");
        for (int i = 0; i < getTime() / 10; i++)
        {
            Console.Write("Breathe in... ");
            Console.Write("\b4");
            Thread.Sleep(1000);
            Console.Write("\b3");
            Thread.Sleep(1000);
            Console.Write("\b2");
            Thread.Sleep(1000);
            Console.Write("\b1");
            Thread.Sleep(1000);
            Console.Write("\b ");
            Console.WriteLine("");
            Console.Write("Now Breathe out... ");
            Console.Write("\b6");
            Thread.Sleep(1000);
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
            Console.WriteLine("\n");



        }

    }

}