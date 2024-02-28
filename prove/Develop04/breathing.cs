using System;
using System.Threading;

namespace mindfullness
{
    class Breathing : Activity
    {
        // Constructor
        public Breathing(string[] prompts) : base("Breathing", prompts) { }

        // Method to start the Breathing activity
        public override void Start(int duration)
        {
            // Display description and program line
            Console.WriteLine($"Starting {GetName()} activity...");
            Console.WriteLine($"Description: {GetDescription()}");
            Console.WriteLine($"Duration for {GetName()} activity (seconds): {duration}");
            
            // Call the base Start method after displaying description
            base.Start(duration);
            
            int secondsElapsed = 0;
            while (secondsElapsed < duration)
            {
                Console.WriteLine("Breathe in...");
                Pause(4);
                secondsElapsed += 4;

                if (secondsElapsed >= duration) // Check if the duration is exceeded
                    break;

                Console.WriteLine("Breathe out...");
                Pause(6);
                secondsElapsed += 6;
            }

            Console.WriteLine($"Well done! You have completed the {GetName()} activity for {duration} seconds.");
            Thread.Sleep(5000);
        }

        // Method to get the description of the Breathing activity
        protected override string GetDescription()
        {
            return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
    }
}