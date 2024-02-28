using System;

namespace mindfullness
{
    class Listing : Activity
    {
        public Listing(string[] prompts) : base("Listing", prompts) { }

        public override void Start(int duration)
        {
            base.Start(duration);
            Random rand = new Random();
            string prompt = GetRandomPrompt(rand);
            Console.WriteLine("Prompt: " + prompt);

            Console.WriteLine("Think about the prompt...");
            Pause(5);

            Console.WriteLine($"You have {duration} seconds to list items. Press enter after each item.");

            int itemCount = 0;
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < endTime)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    itemCount++;
                }
            }

            Console.WriteLine($"You listed {itemCount} items.");

            Console.WriteLine($"Well done! You have completed the Listing activity for {duration} seconds.");
            Thread.Sleep(5000);
        }

        protected override string GetDescription()
        {
            return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }


        private string GetRandomPrompt(Random rand)
        {
            int index = rand.Next(GetPrompts().Length);
            return GetPrompts()[index];
        }
    }
}