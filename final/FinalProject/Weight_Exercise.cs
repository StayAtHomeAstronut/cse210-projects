// Derived Weight_Exercise class
class Weight_Exercise : Exercise
{
    public int Weight { get; set; }
    public int Sets { get; set; }
    public List<int> RepsCompleted { get; set; }

    public Weight_Exercise(string name, int weight, int sets, List<int> repsCompleted) : base(name)
    {
        Weight = weight;
        Sets = sets;
        RepsCompleted = repsCompleted;
        CalculateIntensity();
    }

    public override void CalculateIntensity()
    {
        int totalReps = 0;
        foreach (int reps in RepsCompleted)
        {
            totalReps += reps;
        }
        IntensityRating = (Weight * totalReps) / 10.0;
    }
}