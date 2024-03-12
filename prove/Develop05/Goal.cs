using System;
using System.Collections.Generic;
using System.IO;

//base class

namespace goal
{
    abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsCompleted { get; set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsCompleted = false;
        }

        public abstract void Display();
    }

}