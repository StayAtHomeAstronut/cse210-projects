class Program
{
    static List<Exercise> exercises = new List<Exercise>();

    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Fitness Program Menu:");
            Console.WriteLine("1. Create New Exercise");
            Console.WriteLine("2. Display List of Workouts");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewExercise();
                    break;
                case 2:
                    DisplayWorkouts();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewExercise()
    {
        Console.WriteLine("Choose the type of exercise:");
        Console.WriteLine("1. Aerobic");
        Console.WriteLine("2. Weight");
        Console.Write("Enter your choice: ");
        int exerciseType = int.Parse(Console.ReadLine());

        Console.Write("Enter exercise name: ");
        string name = Console.ReadLine();

        switch (exerciseType)
        {
            case 1:
                Console.Write("Enter duration (in minutes): ");
                int duration = int.Parse(Console.ReadLine());
                Console.Write("Enter target heart rate: ");
                int targetHeartRate = int.Parse(Console.ReadLine());
                exercises.Add(new Aerobic_Exercise(name, duration, targetHeartRate));
                break;
            case 2:
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
                exercises.Add(new Weight_Exercise(name, weight, sets, repsCompleted));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void DisplayWorkouts()
    {
        if (exercises.Count == 0)
        {
            Console.WriteLine("No workouts added yet.");
        }
        else
        {
            Console.WriteLine("List of Workouts:");
            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"Exercise: {exercise.Name}, Intensity: {exercise.IntensityRating}");
            }
        }
    }
}