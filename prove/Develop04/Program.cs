/*
 App that provides three different kinds of mindfulness opportunities.
 Show creativity and exceed requirements by saving the records and adding an option
 to check the total time invested in each activity.
*/
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Loader loader = new Loader();
        Menu menu = new Menu();
        bool running = true;
        while (running)
        {
            menu.Display();
            if (menu.GetOption() == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.setTime();
                activity.GetReady();
                activity.Start();
                activity.Ending();
            }
            else if (menu.GetOption() == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.setTime();
                activity.GetReady();
                activity.Start();
                activity.Ending();
            }
            else if (menu.GetOption() == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.setTime();
                activity.GetReady();
                activity.Start();
                activity.Ending();
            }
            else if (menu.GetOption() == "4")
            {
                Activity activity = new Activity();
                activity.DisplayRecords();
            }else if (menu.GetOption() == "5")
            {
                running = false;
            }
        }
    }
}