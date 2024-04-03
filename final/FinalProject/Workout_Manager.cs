using System;
using System.Collections.Generic;

class Workout_Manager
{
    static List<Exercise> exercises = new List<Exercise>();
    static List<string> workoutTypes = new List<string>();
    static List<Workout> workouts = new List<Workout>();

    public static void CreateNewWorkout(List<Workout> workouts)
    {
        Console.WriteLine("Choose the type of workout:");
        Console.WriteLine("1: Cardio");
        Console.WriteLine("2: Weight");
        Console.Write("Enter your choice: ");
        int workoutTypeChoice = int.Parse(Console.ReadLine());

        string typeDesignation = "";

        if (workoutTypeChoice == 1 || workoutTypeChoice == 2)
        {
            Console.WriteLine("1. Create New Workout Type");
            Console.WriteLine("2. Use Existing Workout Type");
            Console.Write("Enter your choice: ");
            int createUseChoice = int.Parse(Console.ReadLine());

            if (createUseChoice == 1)
            {
                Console.Write("Enter designation (e.g., 'back', 'shoulders', 'legs'): ");
                typeDesignation = Console.ReadLine();
                AddWorkoutType(typeDesignation);
            }
            else if (createUseChoice == 2)
            {
                if (workoutTypes.Count == 0)
                {
                    Console.WriteLine("No existing designations.");
                    Console.Write("Enter designation (e.g., 'back', 'shoulders', 'legs'): ");
                    typeDesignation = Console.ReadLine();
                    AddWorkoutType(typeDesignation);
                }
                else
                {
                    Console.WriteLine("Existing workout types:");
                    for (int i = 0; i < workoutTypes.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {workoutTypes[i]}");
                    }
                    Console.Write("Enter the number associated with the workout type: ");
                    int workoutTypeIndex = int.Parse(Console.ReadLine()) - 1;
                    if (workoutTypeIndex >= 0 && workoutTypeIndex < workoutTypes.Count)
                    {
                        typeDesignation = workoutTypes[workoutTypeIndex];
                    }
                    else
                    {
                        Console.WriteLine("Invalid workout type number.");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            return;
        }

        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter day (1-31): ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        DateTime date = new DateTime(year, month, day);

        List<Exercise> workoutExercises = new List<Exercise>();
        bool finish = false;
        while (!finish)
        {
            Console.WriteLine("Workout Menu:");
            Console.WriteLine("1. Add and log a new exercise");
            Console.WriteLine("2. Log an existing exercise");
            Console.WriteLine("3. Finish");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (workoutTypeChoice == 1)
                    {
                        workoutExercises.Add(CreateAerobicExercise());
                    }
                    else if (workoutTypeChoice == 2)
                    {
                        workoutExercises.Add(CreateWeightExercise());
                    }
                    break;
                case 2:
                    Console.WriteLine("Choose an existing exercise to log:");
                    DisplayExercises(exercises);
                    int exerciseIndex = int.Parse(Console.ReadLine());
                    if (exerciseIndex >= 0 && exerciseIndex < exercises.Count)
                    {
                        Exercise selectedExercise = exercises[exerciseIndex];
                        if (selectedExercise is Aerobic_Exercise && workoutTypeChoice == 1)
                        {
                            workoutExercises.Add(CreateAerobicExercise((Aerobic_Exercise)selectedExercise));
                        }
                        else if (selectedExercise is Weight_Exercise && workoutTypeChoice == 2)
                        {
                            workoutExercises.Add(CreateWeightExercise((Weight_Exercise)selectedExercise));
                        }
                        else
                        {
                            Console.WriteLine("Invalid exercise type for the chosen workout type.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid exercise number.");
                    }
                    break;
                case 3:
                    finish = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        workouts.Add(new Workout(date, typeDesignation, workoutExercises));
        Console.WriteLine($"Workout on {date.ToShortDateString()} completed. Exercises logged:");
        foreach (Exercise exercise in workoutExercises)
        {
            Console.WriteLine($"- {exercise.Name}");
        }
    }

    static void CreateNewExercise()
    {
        Console.WriteLine("Enter exercise details:");
        Console.WriteLine("1. Aerobic");
        Console.WriteLine("2. Weight");
        Console.Write("Enter your choice: ");
        int exerciseType = int.Parse(Console.ReadLine());

        switch (exerciseType)
        {
            case 1:
                exercises.Add(CreateAerobicExercise());
                break;
            case 2:
                exercises.Add(CreateWeightExercise());
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static Aerobic_Exercise CreateAerobicExercise()
    {
        Console.Write("Enter exercise name: ");
        string name = Console.ReadLine();
        Console.Write("Enter duration (in minutes): ");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("Enter target heart rate: ");
        int targetHeartRate = int.Parse(Console.ReadLine());
        Aerobic_Exercise exercise = new Aerobic_Exercise(name, duration, targetHeartRate);
        return exercise;
    }

    static Weight_Exercise CreateWeightExercise()
    {
        Console.Write("Enter exercise name: ");
        string name = Console.ReadLine();
        Console.Write("Enter weight (in pounds): ");
        int weight = int.Parse(Console.ReadLine());
        Console.Write("Enter number of sets: ");
        int sets = int.Parse(Console.ReadLine());
        List<int> repsCompleted = new List<int>();
        for (int i = 0; i < sets; i++)
        {
            Console.Write($"Enter number of reps completed for set {i + 1}: ");
            repsCompleted.Add(int.Parse(Console.ReadLine()));
        }
        Weight_Exercise exercise = new Weight_Exercise(name, weight, sets, repsCompleted);
        return exercise;
    }

    static Aerobic_Exercise CreateAerobicExercise(Aerobic_Exercise existingExercise)
    {
        Console.Write("Enter duration (in minutes): ");
        int duration = int.Parse(Console.ReadLine());
        Console.Write("Enter target heart rate: ");
        int targetHeartRate = int.Parse(Console.ReadLine());
        Aerobic_Exercise exercise = new Aerobic_Exercise(existingExercise.Name, duration, targetHeartRate);
        return exercise;
    }

    static Weight_Exercise CreateWeightExercise(Weight_Exercise existingExercise)
    {
        Console.Write("Enter weight (in pounds): ");
        int weight = int.Parse(Console.ReadLine());
        Console.Write("Enter number of sets: ");
        int sets = int.Parse(Console.ReadLine());
        List<int> repsCompleted = new List<int>();
        for (int i = 0; i < sets; i++)
        {
            Console.Write($"Enter number of reps completed for set {i + 1}: ");
            repsCompleted.Add(int.Parse(Console.ReadLine()));
        }
        Weight_Exercise exercise = new Weight_Exercise(existingExercise.Name, weight, sets, repsCompleted);
        return exercise;
    }

    public static void DisplayExercises(List<Exercise> exercises)
    {
        for (int i = 0; i < exercises.Count; i++)
        {
            Console.WriteLine($"{i}. {exercises[i].Name}");
        }
    }

    public static void DisplayWorkouts()
    {
        if (workouts.Count == 0)
        {
            Console.WriteLine("No workouts added yet.");
        }
        else
        {
            Console.WriteLine("List of Workouts:");
            foreach (Workout workout in workouts)
            {
                Console.WriteLine($"{workout.Date.ToShortDateString()}");
                foreach (Exercise exercise in workout.Exercises)
                {
                    Console.WriteLine($"- {exercise.Name}, Intensity: {exercise.IntensityRating}");
                }
            }
        }
    }

    private static void AddWorkoutType(string typeDesignation)
    {
        if (!workoutTypes.Contains(typeDesignation))
        {
            workoutTypes.Add(typeDesignation);
            Console.WriteLine("Workout type added successfully.");
        }
        else
        {
            Console.WriteLine("Workout type already exists.");
        }
    }
}