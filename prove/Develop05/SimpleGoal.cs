using System;
using System.Collections.Generic;
using System.IO;

//subclass

namespace goal
{
    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override void Display()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {Name}");
        }
    }
}