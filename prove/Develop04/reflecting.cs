using System;
using System.Threading;
using System.Linq;

namespace mindfullness
{
    class Reflecting : Activity
    {
        // Constructor
        public Reflecting(string[] prompts) : base("Reflecting", prompts) { }

        // Method to start the Reflecting activity
        public override void Start(int duration)
        {
            // Display description, prompt, and program line
            Console.WriteLine($"Starting {GetName()} activity...");
            Console.WriteLine($"\nDescription: {GetDescription()}");
            Console.WriteLine($"\nPress Any Key to Continue");
            Console.ReadLine();
            Console.Clear();
            
            Random rand = new Random();
            string prompt = GetRandomPrompt(rand);
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("When You Have Something In Mind, Press Any Key: ");
            Console.ReadLine();

            string[] questions = GetQuestions().OrderBy(x => rand.Next()).ToArray(); // Shuffle questions
            int secondsElapsed = 0;
            int questionIndex = 0;

            while (secondsElapsed < duration)
            {
                Console.WriteLine(questions[questionIndex]);
                Pause(10);
                secondsElapsed += 10;

                questionIndex++;
                if (questionIndex >= questions.Length)
                    questionIndex = 0;
            }

            Console.WriteLine($"Well done! You have completed the Reflection activity for {duration} seconds.");
            Thread.Sleep(5000);
        }

        // Method to get a random prompt
        private string GetRandomPrompt(Random rand)
        {
            int index = rand.Next(GetPrompts().Length);
            return GetPrompts()[index];
        }

        // Method to get the description of the Reflecting activity
        protected override string GetDescription()
        {
            return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        // Method to get the questions for reflection
        private string[] GetQuestions()
        {
            // Sample list of questions
            return new string[]
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }
    }
}