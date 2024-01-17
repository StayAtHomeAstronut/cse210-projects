using System;

class Program
{
    static void Main(string[] args)
    {

        Random random = new Random();
        int mNumber = random.Next(1, 100);

        int guess = -1;

        while (guess != mNumber)
        {
            Console.Write("Guess a random number between 1 and 100: ");
            guess = int.Parse(Console.ReadLine());

            if (mNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (mNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed the number! It was: {mNumber}.");
            }

        }                    
    }
}