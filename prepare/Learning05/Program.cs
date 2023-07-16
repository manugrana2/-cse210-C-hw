using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");

        Square square = new Square(5);
        Console.WriteLine("The area of the square is: " + square.GetArea());

        Rectangle rectangle = new Rectangle(5, 7);
        Console.WriteLine("The area of the rectangle is: " + rectangle.GetArea());

        Circle circle = new Circle(3);
        Console.WriteLine("The area of the circle is: " + circle.GetArea());
    }
}
