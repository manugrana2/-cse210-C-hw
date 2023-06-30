public class Menu{
    private string _option;

    public string GetOption(){
        return _option;
    }
    public void Display(){
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start Breathing Activity");
        Console.WriteLine("2. Start Reflecting Activity");
        Console.WriteLine("3. Start Listening Activity");
        Console.WriteLine("4. List Records");
        Console.WriteLine("5. Quit");
        Console.Write("\n Select a choice from the menu: ");
        _option = Console.ReadLine();
    }
}