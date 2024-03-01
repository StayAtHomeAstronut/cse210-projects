using System;
using System.Threading;

namespace mindfullness
{
    class Breathing : Activity
    {
        // Constructor
        public Breathing(string[] prompts) : base("Breathing", prompts) { }

        // starts the Breathing activity
        public override void Start(int duration)
        {
            // Displays description and program line
            Console.WriteLine($"Starting {GetName()} activity...");
            Console.WriteLine($"Description: {GetDescription()}");
            Console.WriteLine($"Duration for {GetName()} activity (seconds): {duration}");
            
            // Calls the Start method after displaying description
            base.Start(duration);
            
            int secondsElapsed = 0;
            while (secondsElapsed < duration)
            {
                Console.WriteLine("Breathe in");

                Console.Write(".");
                Thread.Sleep(666);
                Console.Write(".");
                Thread.Sleep(666);
                Console.Write(".");
                Thread.Sleep(666);
                Console.Write(".");
                Thread.Sleep(666);
                Console.Write(".");
                Thread.Sleep(666);
                Console.Write(".");
                Thread.Sleep(670);
                Console.Clear();

                secondsElapsed += 4;

                if (secondsElapsed >= duration) // Check if the duration is exceeded
                    break;

                Console.WriteLine("Breathe out");
                Console.Write("......");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                Console.Clear();

                secondsElapsed += 6;
            }

            Console.WriteLine($"Well done! You have completed the {GetName()} activity for {duration} seconds.");
            Thread.Sleep(5000);
        }

        // the description of the Breathing activity
        protected override string GetDescription()
        {
            return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
    }
}