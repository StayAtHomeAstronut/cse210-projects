using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        float percentage = float.Parse(Console.ReadLine());
        string letter;

        if (percentage >=90)
        {
            letter = "n A";
        }
        else if (percentage>=80)
        {
            letter = " B";
        }
        else if (percentage>=70)
        {
            letter = " C";
        }
        else if (percentage >=60)
        {
            letter = " D";
        }
        else
        {
            letter = "n F";
        }

        Console.WriteLine($"Your Grade is a{letter}.");

        if (percentage >=70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else{
            Console.WriteLine("Unfortunately, you did not pass. Try again!");
        }
    }
}