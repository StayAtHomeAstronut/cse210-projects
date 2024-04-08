using System;
using System.Collections.Generic;
using System.IO;

class Logger
{
    private string username;
    private string filename;

    public Logger(string username)
    {
        this.username = username;
        this.filename = $"fitness_tracker_{username}.txt";
    }

    public void LogWorkout(Workout workout)
    {
        // Append the workout information to the text file
        using (StreamWriter writer = File.AppendText(filename))
        {
            writer.WriteLine($"Date: {workout.Date.ToShortDateString()}, Type: {workout.WorkoutType}");
            foreach (var exercise in workout.Exercises)
            {
                writer.WriteLine($"- {exercise.Name}, Intensity: {exercise.IntensityRating}");
            }
            writer.WriteLine();
        }
    }

    public List<Workout> LoadWorkoutHistory()
    {
        List<Workout> loadedWorkouts = new List<Workout>();

        try
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);

                DateTime date = DateTime.MinValue;
                string type = "";
                List<Exercise> exercises = new List<Exercise>();

                foreach (string line in lines)
                {
                    if (line.StartsWith("Date:"))
                    {
                        if (date != DateTime.MinValue && !string.IsNullOrEmpty(type) && exercises.Count > 0)
                        {
                            loadedWorkouts.Add(new Workout(date, type, exercises));
                            exercises = new List<Exercise>(); // Reset exercises for the next workout
                        }

                        // Parse date and type from the line
                        string[] parts = line.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 4)
                        {
                            date = DateTime.Parse(parts[1].Trim());
                            type = parts[3].Trim();
                        }
                    }
                    else if (line.StartsWith("- "))
                    {
                        // Parse exercise name and intensity from the line
                        string[] exerciseParts = line.Substring(2).Split(new string[] { ", Intensity: " }, StringSplitOptions.None);
                        if (exerciseParts.Length == 2)
                        {
                            string exerciseName = exerciseParts[0].Trim();
                            float intensity = float.Parse(exerciseParts[1].Trim());

                            // Create Exercise object and add it to the list
                            Exercise exercise = new Exercise(exerciseName);
                            exercise.IntensityRating = intensity; // Assign intensity rating
                            exercises.Add(exercise);
                        }
                    }
                }

                // Add the last workout to the list
                if (date != DateTime.MinValue && !string.IsNullOrEmpty(type) && exercises.Count > 0)
                {
                    loadedWorkouts.Add(new Workout(date, type, exercises));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading workout history: {ex.Message}");
        }

        return loadedWorkouts;
    }

    public void SaveWorkoutHistory(List<Workout> workouts)
    {
        try
        {
            // Overwrite the entire workout history to the text file
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var workout in workouts)
                {
                    writer.WriteLine($"Date: {workout.Date.ToShortDateString()}, Type: {workout.WorkoutType}");
                    foreach (var exercise in workout.Exercises)
                    {
                        writer.WriteLine($"- {exercise.Name}, Intensity: {exercise.IntensityRating}");
                    }
                    writer.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving workout history: {ex.Message}");
        }
    }
}