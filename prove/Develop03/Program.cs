using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Proverbs 3:5-6");
        var scripture = new Scripture(reference, "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways acknowledge him, and he will make your paths straight.");

        scripture.Display();

        while (true)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();
            Console.Clear();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Restart the program to play again.");
                break;
            }
        }
    }
}