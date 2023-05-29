using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let's determine the letter grade for a course");
        Console.WriteLine("Please provide your grading percentage");
        string grading = Console.ReadLine();
        float grad;
        string gradSign = string.Empty;
        string gradLetter = string.Empty;
        float lastDigit;
        if(float.TryParse(grading, out grad)){
            if(grad >= 90){
                gradLetter = "A";
            }else if(grad >= 80){
                gradLetter = "B";
            }else if(grad >= 70){
                gradLetter = "C";
            }else if(grad >= 70){
                gradLetter = "D";
            }else if(grad < 70){
                gradLetter = "F";
            }
            Console.WriteLine($"Your gradding letter is {gradLetter}");

        }else{
            Console.WriteLine("Error! Your gradding percentaje should not include other signs than numbers");
        }
        if(float.TryParse(grading, out grad) && gradLetter != "A"){
            lastDigit = grad % 10;
            if(lastDigit >= 7){
                gradSign = "+";
            }else if(lastDigit < 3){
                 gradSign = "-";
            }
            Console.WriteLine($"Your gradding is {gradLetter}{gradSign}");
        }

    }
}