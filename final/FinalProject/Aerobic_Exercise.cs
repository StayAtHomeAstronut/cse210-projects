// Derived Aerobic_Exercise class
class Aerobic_Exercise : Exercise
{
    public int Duration { get; set; }
    public int TargetHeartRate { get; set; }

    public Aerobic_Exercise(string name, int duration, int targetHeartRate) : base(name)
    {
        Duration = duration;
        TargetHeartRate = targetHeartRate;
        CalculateIntensity();
    }

    public override void CalculateIntensity()
    {
        IntensityRating = (Duration * TargetHeartRate) / 10.0;
    }
}