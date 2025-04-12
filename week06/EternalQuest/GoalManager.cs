// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private readonly List<Goal> _goals = new List<Goal>();
        private int _totalPoints = 0;

        public void CreateGoal()
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            Goal goal = null;
            if (type == 1)
            {
                goal = new SimpleGoal(name, description, points);
            }
            else if (type == 2)
            {
                goal = new EternalGoal(name, description, points);
            }
            else if (type == 3)
            {
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
            }
            if (goal != null) _goals.Add(goal);
        }

        public void ListGoals()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void RecordGoalEvent()
        {
            Console.WriteLine("Which goal did you accomplish?");
            ListGoals();
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < _goals.Count)
            {
                Goal goal = _goals[index];
                goal.RecordEvent();
                _totalPoints += goal.GetPoints();

                if (goal is ChecklistGoal checklist && checklist.IsComplete() && checklist.GetCompletedCount() == checklist.GetTargetCount())
                {
                    _totalPoints += checklist.GetBonusPoints();
                    Console.WriteLine($"You earned a bonus of {checklist.GetBonusPoints()} points!");
                }
            }
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save: ");
            string file = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.WriteLine(_totalPoints);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load: ");
            string file = Console.ReadLine();
            _goals.Clear();
            string[] lines = File.ReadAllLines(file);
            _totalPoints = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal goal = null;
                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);
                    SimpleGoal simple = new SimpleGoal(name, description, points);
                    if (isComplete) simple.RecordEvent();
                    goal = simple;
                }
                else if (type == "EternalGoal")
                {
                    goal = new EternalGoal(name, description, points);
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int completed = int.Parse(parts[6]);
                    ChecklistGoal checklist = new ChecklistGoal(name, description, points, target, bonus);
                    for (int c = 0; c < completed; c++) checklist.RecordEvent();
                    goal = checklist;
                }
                if (goal != null) _goals.Add(goal);
            }
        }

        public int GetTotalPoints() => _totalPoints;

        public string GetLevel()
        {
            if (_totalPoints < 500)
                return "Level 1 – Novice";
            else if (_totalPoints < 1000)
                return "Level 2 – Achiever";
            else if (_totalPoints < 2000)
                return "Level 3 – Expert";
            else
                return "Level 4 – Champion";
        }
    }
}