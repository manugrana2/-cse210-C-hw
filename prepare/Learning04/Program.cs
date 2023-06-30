using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathtest = new MathAssignment("Roberto Perez", "Graphs", "7", "5-10");
        Console.WriteLine(mathtest.GetSummary());
        Console.WriteLine(mathtest.GetHomeworkList());
        WritingAssignment writingtest = new WritingAssignment("Maria Florez", "Industrial Revolution", "The effects on industrial revolution on goods access");
        Console.WriteLine(writingtest.GetSummary());
        Console.WriteLine(writingtest.GetWritingInformation());
    }
}