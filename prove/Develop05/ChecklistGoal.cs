using System;
using System.Collections.Generic;
using System.IO;

//subclass

namespace goal
{
    class ChecklistGoal : Goal
    {
        public int TargetCount { get; private set; }
        public int CompletedCount { get; private set; }
        public int BonusPoints { get; private set; }

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CompletedCount = 0;
        }

        public override void Display()
        {
            string status = IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {Name} ({CompletedCount}/{TargetCount})");
        }

        public void RecordEvent()
        {
            CompletedCount++;
            if (CompletedCount >= TargetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Congratulations! You have completed the checklist goal: {Name}");
                Points += BonusPoints;
            }
        }
    }
}