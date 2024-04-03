using System;
using System.Collections.Generic;

class Program
{
    static List<Workout> workouts = new List<Workout>(); // Declare list of workouts at the class level
    static List<string> workoutTypes = new List<string>(); // Declare list of workout types at the class level
    static List<Exercise> exercises = new List<Exercise>(); // Declare list of exercises at the class level
    static Logger logger;

    static void Main(string[] args)
    {
        bool exit = false;

        // Log in or create account
        Console.WriteLine("Welcome to the Fitness Program!");
        Console.WriteLine("1. Log in");
        Console.WriteLine("2. Create an account");
        Console.Write("Enter your choice: ");
        int loginChoice = int.Parse(Console.ReadLine());

        switch (loginChoice)
        {
            case 1:
                Console.Write("Enter your username: ");
                string existingUsername = Console.ReadLine();
                logger = new Logger(existingUsername);
                break;
            case 2:
                Console.Write("Enter a new username: ");
                string newUsername = Console.ReadLine();
                logger = new Logger(newUsername);
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting program.");
                return;
        }

        // Load workout history
        workouts = logger.LoadWorkoutHistory();

        while (!exit)
        {
            Console.WriteLine("Fitness Program Menu:");
            Console.WriteLine("1. Create New Workout");
            Console.WriteLine("2. View Workout History");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewWorkout();
                    break;
                case 2:
                    ViewWorkoutHistory();
                    break;
                case 3:
                    exit = true;
                    SaveWorkoutHistory();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void CreateNewWorkout()
    {
        Console.WriteLine("Choose the type of workout:");
        Console.WriteLine("1. Aerobic");
        Console.WriteLine("2. Weight");
        Console.Write("Enter your choice: ");
        int workoutTypeChoice = int.Parse(Console.ReadLine());

        string typeDesignation = "";

        if (workoutTypeChoice == 1)
        {
            typeDesignation = "Aerobic";
        }
        else if (workoutTypeChoice == 2)
        {
            typeDesignation = "Weight";
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
            return;
        }

        Console.WriteLine("Choose the workout designation:");
        Console.WriteLine("1. Create New Designation");
        Console.WriteLine("2. Use Existing Designation");
        Console.Write("Enter your choice: ");
        int workoutDesignationChoice = int.Parse(Console.ReadLine());

        string designation = "";

        if (workoutDesignationChoice == 1)
        {
            Console.Write("Enter designation (e.g., 'back', 'chest', 'legs'): ");
            designation = Console.ReadLine();
            if (!workoutTypes.Contains(designation))
            {
                workoutTypes.Add(designation);
            }
        }
        else if (workoutDesignationChoice == 2)
        {
            if (workoutTypes.Count == 0)
            {
                Console.WriteLine("No existing designations.");
                Console.Write("Enter designation (e.g., 'back', 'chest', 'legs'): ");
                designation = Console.ReadLine();
                workoutTypes.Add(designation);
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
                    designation = workoutTypes[workoutTypeIndex];
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
            Console.WriteLine("1: Add and log a new exercise");
            Console.WriteLine("2: Log an existing Exercise");
            Console.WriteLine("3. Finish");
            Console.Write("Enter your choice: ");
            int exerciseChoice = int.Parse(Console.ReadLine());

            switch (exerciseChoice)
            {
                case 1:
                    Console.Write("Enter exercise name: ");
                    string exerciseName = Console.ReadLine();
                    exercises.Add(new Exercise(exerciseName)); // Store the exercise name in the list
                    // Prompt user for exercise details based on type
                    if (workoutTypeChoice == 1)
                    {
                        workoutExercises.Add(CreateAerobicExercise(exerciseName));
                    }
                    else if (workoutTypeChoice == 2)
                    {
                        workoutExercises.Add(CreateWeightExercise(exerciseName));
                    }
                    break;
                case 2:
                    if (exercises.Count == 0)
                    {
                        Console.WriteLine("No logged exercises.");
                        // Perform logic to create a new exercise
                        Console.Write("Enter exercise name: ");
                        string newExerciseName = Console.ReadLine();
                        exercises.Add(new Exercise(newExerciseName));
                        // Prompt user for exercise details based on type
                        if (workoutTypeChoice == 1)
                        {
                            workoutExercises.Add(CreateAerobicExercise(newExerciseName));
                        }
                        else if (workoutTypeChoice == 2)
                        {
                            workoutExercises.Add(CreateWeightExercise(newExerciseName));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Choose an existing exercise to log:");
                        DisplayExercises();
                        int exerciseIndex = int.Parse(Console.ReadLine());
                        if (exerciseIndex >= 0 && exerciseIndex < exercises.Count)
                        {
                            Exercise selectedExercise = exercises[exerciseIndex];
                            // Prompt user for exercise details based on type
                            if (workoutTypeChoice == 1)
                            {
                                workoutExercises.Add(CreateAerobicExercise(selectedExercise.Name));
                            }
                            else if (workoutTypeChoice == 2)
                            {
                                workoutExercises.Add(CreateWeightExercise(selectedExercise.Name));
                            }
                        }
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

        workouts.Add(new Workout(date, designation, workoutExercises));
        Console.WriteLine($"Workout on {date.ToShortDateString()} completed. Exercises logged:");
        foreach (Exercise exercise in workoutExercises)
        {
            Console.WriteLine($"- {exercise.Name}");
        }

        // Log the workout to the logger
        logger.LogWorkout(workouts[workouts.Count - 1]);
    }

    static Aerobic_Exercise CreateAerobicExercise(string exerciseName)
    {
        Console.Write($"Enter duration for {exerciseName} (in minutes): ");
        int duration = int.Parse(Console.ReadLine());
        Console.Write($"Enter intensity for {exerciseName}: ");
        int intensity = int.Parse(Console.ReadLine());
        return new Aerobic_Exercise(exerciseName, duration, intensity);
    }

    static Weight_Exercise CreateWeightExercise(string exerciseName)
    {
        Console.Write($"Enter weight for {exerciseName} (in pounds): ");
        int weight = int.Parse(Console.ReadLine());
        Console.Write($"Enter number of sets for {exerciseName}: ");
        int sets = int.Parse(Console.ReadLine());
        List<int> repsCompleted = new List<int>();
        for (int i = 0; i < sets; i++)
        {
            Console.Write($"Enter number of reps completed for set {i + 1} of {exerciseName}: ");
            repsCompleted.Add(int.Parse(Console.ReadLine()));
        }
        return new Weight_Exercise(exerciseName, weight, sets, repsCompleted);
    }

    static void DisplayExercises()
    {
        for (int i = 0; i < exercises.Count; i++)
        {
            Console.WriteLine($"{i}: {exercises[i].Name}");
        }
    }

    static void ViewWorkoutHistory()
    {
        if (workouts.Count == 0)
        {
            Console.WriteLine("No workouts recorded yet.");
        }
        else
        {
            Console.WriteLine("Workout History:");
            foreach (var workout in workouts)
            {
                Console.WriteLine($"Date: {workout.Date.ToShortDateString()}");
                Console.WriteLine($"Type: {workout.WorkoutType}");
                Console.WriteLine($"Intensity: {workout.TotalIntensity}");

                Console.WriteLine("Exercises:");
                foreach (var exercise in workout.Exercises)
                {
                    Console.WriteLine($"- {exercise.Name}, Intensity: {exercise.IntensityRating}");
                }
            }
        }
    }

    static void SaveWorkoutHistory()
    {
        // Save workout history to the logger before exiting the program
        logger.SaveWorkoutHistory(workouts);
    }
}