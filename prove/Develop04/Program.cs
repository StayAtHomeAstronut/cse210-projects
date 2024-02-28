using System;
using System.Threading;

namespace mindfullness
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] breathingPrompts = { };
            string[] reflectionPrompts = { "Think of a time when you stood up for someone else.",
                                        "Think of a time when you did something really difficult.",
                                        "Think of a time when you helped someone in need.",
                                        "Think of a time when you did something truly selfless." };
            string[] listingPrompts = { "Who are people that you appreciate?",
                                        "What are personal strengths of yours?",
                                        "Who are people that you have helped this week?",
                                        "When have you felt the Holy Ghost this month?",
                                        "Who are some of your personal heroes?" };

            Breathing breathingActivity = new Breathing(breathingPrompts);
            Reflecting reflectionActivity = new Reflecting(reflectionPrompts);
            Listing listingActivity = new Listing(listingPrompts);

            Console.WriteLine("Welcome to the Mindfulness Program!");

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Quit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Console.Write("Duration for Breathing activity (seconds): ");
                        int breathingDuration = int.Parse(Console.ReadLine());
                        breathingActivity.Start(breathingDuration);
                        break;
                    case 2:
                        Console.Write("Duration for Reflection activity (seconds): ");
                        int reflectionDuration = int.Parse(Console.ReadLine());
                        reflectionActivity.Start(reflectionDuration);
                        break;
                    case 3:
                        Console.Write("Duration for Listing activity (seconds): ");
                        int listingDuration = int.Parse(Console.ReadLine());
                        listingActivity.Start(listingDuration);
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
        }
    }
}