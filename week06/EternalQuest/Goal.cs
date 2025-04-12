using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public virtual string GetDetailsString()
        {
            return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})";
        }
        public abstract string GetStringRepresentation();
        public int GetPoints() => _points;
    }
}