using System;
using System.Collections.Generic;
using System.IO;

//subclass

namespace goal
{
    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override void Display()
        {
            Console.WriteLine($"[ ] {Name} (Eternal)");
        }
    }
}