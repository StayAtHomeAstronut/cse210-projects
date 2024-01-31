using System;
using System.Collections.Generic;
using System.Text;

namespace journal
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();

            while (true)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                                //OPTION 1: write an entry

                    case 1:
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Choose a random prompt");
                        Console.WriteLine("2. Enter your own prompt");

                        int promptChoice = int.Parse(Console.ReadLine());

                        string prompt;
                        if (promptChoice == 1)
                        {
                            // Choose a random predefined prompt
                            prompt = GetRandomPredefinedPrompt();
                            Console.WriteLine($"Random Prompt: {prompt}");
                        }
                        else if (promptChoice == 2)
                        {
                            // Allow the user to enter their own prompt
                            Console.WriteLine("Enter your own prompt:");
                            prompt = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Using a random prompt.");
                            prompt = GetRandomPredefinedPrompt(); // Default to a random predefined prompt
                            Console.WriteLine($"Random Prompt: {prompt}");
                        }

                        Console.WriteLine("Enter your response to the prompt:");
                        string response = Console.ReadLine();
                        Entry newEntry = new Entry(response, prompt);
                        myJournal.AddEntry(newEntry);
                        break;


                                //OPTION 2: display the entries

                    case 2:
                        myJournal.Display();
                        break;

                                //OPTION 3: save the entries to a file and export

                    case 3:
                        Console.WriteLine("Enter the filename to save the journal:");
                        string filenameSave = Console.ReadLine();
                        try
                        {
                            System.IO.File.WriteAllText(filenameSave, myJournal.Export());
                            Console.WriteLine("Journal saved successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving journal: {ex.Message}");
                        }
                        break;

                                //OPTION 4: load and display the journal

                    case 4:
                        Console.WriteLine("Enter the filename to load the journal:");
                        string filenameLoad = Console.ReadLine();
                        try
                        {
                            string data = System.IO.File.ReadAllText(filenameLoad);
                            myJournal = new Journal();
                            myJournal.Import(data);
                            
                            //Write this to let the user know the journal has been successfully loaded.
                            Console.WriteLine("Journal loaded successfully. Displaying contents:");
                            myJournal.Display();
                        }
                        catch (Exception ex)
                        {
                            //Write this in case the program cannot find the file (user may need to specify the path)
                            Console.WriteLine($"Error loading journal: {ex.Message}");
                        }
                        break;

                                //OPTION 5: quit the program

                    case 5:
                        Environment.Exit(0);
                        break;

                                //NOT AN OPTION: handle cases where there is an invalid input

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private static string GetRandomPredefinedPrompt()
        {
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            Random random = new Random();
            int randomIndex = random.Next(prompts.Length);
            return prompts[randomIndex];
        }
    }
}