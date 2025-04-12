namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private readonly int _targetCount;
        private int _completedCount;
        private readonly int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _completedCount = 0;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent()
        {
            if (_completedCount < _targetCount)
            {
                _completedCount++;
            }
        }

        public override bool IsComplete()
        {
            return _completedCount >= _targetCount;
        }

        public override string GetDetailsString()
        {
            return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- Completed {_completedCount}/{_targetCount}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{_name}|{_description}|{_points}|{_bonusPoints}|{_targetCount}|{_completedCount}";
        }

        public int GetBonusPoints() => _bonusPoints;
        public int GetCompletedCount() => _completedCount;
        public int GetTargetCount() => _targetCount;
    }
}