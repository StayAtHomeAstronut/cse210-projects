using System;
using System.Collections.Generic;
using System.IO;

namespace goal{

    class Program
    {
        static GoalManager goalManager = new GoalManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");

            LoadPoints(); // Load points when the program starts

            int choice;
            do
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        goalManager.ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            } while (choice != 6);
        }

        static void LoadPoints()
        {
            Console.Write("Enter file path to load data\nOr Press ENTER to start a new game: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    goalManager.Points = int.Parse(reader.ReadLine()); // Load total points first
                    goalManager.LoadGoals(filePath);; // Load goals
                }
                Console.WriteLine($"Data loaded successfully! Current Points: {goalManager.Points}");
            }
            else
            {
                Console.WriteLine("Data file does not exist. Starting with 0 points and no goals.");
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("\nCreating a new goal:");

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. Eternal");
            Console.WriteLine("3. Checklist");

            Console.Write("Enter your choice: ");
            int typeChoice = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case 1:
                case 2:
                    goalManager.CreateGoal(name, points, typeChoice);
                    break;
                case 3:
                    Console.Write("Enter the number of checks in the checklist: ");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goalManager.CreateGoal(name, points, typeChoice, targetCount, bonusPoints);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not created.");
                    break;
            }
        }

        static void SaveGoals()
        {
            Console.Write("Enter file path to save goals: ");
            string filePath = Console.ReadLine();
            goalManager.SaveGoals(filePath);
        }

        static void LoadGoals()
        {
            Console.Write("Enter file path to load goals: ");
            string filePath = Console.ReadLine();
            goalManager.LoadGoals(filePath);
        }

        static void RecordEvent()
        {
            Console.WriteLine("\nRecording event:");

            goalManager.ListGoals();

            Console.Write("Enter the number associated with the goal to record event: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            goalManager.RecordEvent(index);
        }
    }
}