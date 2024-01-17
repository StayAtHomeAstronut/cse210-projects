using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int myNumber = -1;
        while (myNumber != 0)
        {
            Console.Write("Enter a whole number, or quit with 0: ");
            
            string userResponse = Console.ReadLine();
            myNumber = int.Parse(userResponse);
            if (myNumber != 0)
            {
                numbers.Add(myNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}