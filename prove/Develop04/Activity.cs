using System;
using System.Threading;

namespace mindfullness
{
    // Class will be inherited by other activities
    class Activity
    {
        private string name;
        private string[] prompts;

        // initialize name and prompts
        public Activity(string name, string[] prompts)
        {
            this.name = name;
            this.prompts = prompts;
        }

        // start the activity
        public virtual void Start(int duration)
        {
            Console.WriteLine($"\nStarting {name} activity...");
            Console.WriteLine($"Description: {GetDescription()}");
            Console.WriteLine($"\nPress Any Key To Begin:");
            Console.ReadLine();
            Console.Clear();
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("\nGet ready...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("Go!");
        }

        // get the description of the activity
        protected virtual string GetDescription()
        {
            return "";
        }

        // pause execution
        protected void Pause(int seconds)
        {
            // Display animation during pause
            int millisecondsPerFrame = 200;
            int frames = seconds * 1000 / millisecondsPerFrame;

            for (int i = 0; i < frames; i++)
            {
                // Print the characters in the spinning line
                switch (i % 4)
                {
                    case 0:
                        Console.Write("-");
                        break;
                    case 1:
                        Console.Write("/");
                        break;
                    case 2:
                        Console.Write("|");
                        break;
                    case 3:
                        Console.Write("\\");
                        break;
                }

                // Wait before printing the next character
                Thread.Sleep(millisecondsPerFrame);

                // Move the cursor back to overwrite the previous character
                Console.Write("\b \b");
            }

            // Clear the spinning line after the animation is finished
            Console.Write(" ");

            // Move the cursor back to the next line
            Console.WriteLine();
        }

        // Gets the name of the activity
        public string GetName()
        {
            return name;
        }

        // Gets the prompts of the activity
        public string[] GetPrompts()
        {
            return prompts;
        }
    }
}