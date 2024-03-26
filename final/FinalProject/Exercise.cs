// Base Exercise class
class Exercise
{
    public string Name { get; set; }
    public double IntensityRating { get; protected set; } // Intensity rating defined by the base class

    public Exercise(string name)
    {
        Name = name;
    }

    public virtual void CalculateIntensity()
    {
        // Intensity calculation can be overridden by derived classes
    }
}