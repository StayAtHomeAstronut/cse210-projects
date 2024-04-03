class Workout
{
    public DateTime Date { get; }
    public string WorkoutType { get; }
    public List<Exercise> Exercises { get; }
    public double TotalIntensity { get; }

    public Workout(DateTime date, string workoutType, List<Exercise> exercises)
    {
        Date = date;
        WorkoutType = workoutType;
        Exercises = exercises;

        // Calculate total intensity
        TotalIntensity = 0;
        foreach (var exercise in exercises)
        {
            TotalIntensity += exercise.IntensityRating;
        }
    }
}