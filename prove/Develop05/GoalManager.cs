using System;
using System.Collections.Generic;
using System.IO;

//Goal Manager Class
namespace goal
{
    class GoalManager
    {
        private List<Goal> goals = new List<Goal>();
        private int points = 0;

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public void CreateGoal(string name, int points, int type, int targetCount = 0, int bonusPoints = 0)
        {
            switch (type)
            {
                case 1:
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case 2:
                    goals.Add(new EternalGoal(name, points));
                    break;
                case 3:
                    goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    break;
            }
        }

        public void ListGoals()
        {
            Console.WriteLine($"\nCurrent Points: {points}");
            Console.WriteLine("Listing goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].Display();
            }
        }

        public void SaveGoals(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(points); // Save total points first
                    foreach (var goal in goals)
                    {
                        if (goal is ChecklistGoal checklistGoal)
                        {
                            // Write all data for checklist goals
                            writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.IsCompleted},{checklistGoal.TargetCount},{checklistGoal.CompletedCount},{checklistGoal.BonusPoints}");
                        }
                        else
                        {
                            // Write data for other types of goals
                            writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.IsCompleted}");
                        }
                    }
                }

                Console.WriteLine("Goals saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals(string filePath)
        {
            goals.Clear();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    points = int.Parse(reader.ReadLine()); // Load total points first
                    string line;
                    int lineCount = 1; // Track line number for error reporting
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length < 4) // Check if line has enough elements
                        {
                            Console.WriteLine($"Error loading goal on line {lineCount}: Insufficient data.");
                            continue;
                        }

                        string type = parts[0];
                        string name = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isCompleted = bool.Parse(parts[3]);

                        switch (type)
                        {
                            case "SimpleGoal":
                                goals.Add(new SimpleGoal(name, points) { IsCompleted = isCompleted });
                                break;
                            case "EternalGoal":
                                goals.Add(new EternalGoal(name, points) { IsCompleted = isCompleted });
                                break;
                            case "ChecklistGoal":
                                if (parts.Length < 7) // Check if line has enough elements for checklist goals
                                {
                                    Console.WriteLine($"Error loading checklist goal on line {lineCount}: Insufficient data.");
                                    continue;
                                }

                                int targetCount = int.Parse(parts[4]);
                                int completedCount = int.Parse(parts[5]);
                                int bonusPoints = int.Parse(parts[6]);
                                var checklistGoal = new ChecklistGoal(name, points, targetCount, bonusPoints) { IsCompleted = isCompleted };
                                for (int i = 0; i < completedCount; i++)
                                {
                                    checklistGoal.RecordEvent();
                                }
                                goals.Add(checklistGoal);
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type: {type}. Skipping...");
                                break;
                        }

                        lineCount++;
                    }
                }

                Console.WriteLine("Goals loaded successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }

        public void RecordEvent(int index)
        {
            if (index >= 0 && index < goals.Count)
            {
                var goal = goals[index];
                if (!goal.IsCompleted)
                {
                    goal.Display(); // Display before recording event to show initial state
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        checklistGoal.RecordEvent();
                    }
                    else
                    {
                        goal.IsCompleted = true;
                        points += goal.Points; // Increment points only when a goal is fully completed
                    }
                    Console.WriteLine("Event recorded successfully!");
                }
                else
                {
                    Console.WriteLine("This goal has already been completed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
    }
}