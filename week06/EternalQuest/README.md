# Eternal Quest Program

## 📘 Overview
The **Eternal Quest Program** is a gamified goal-tracking console application built in C#. Inspired by the idea of personal and spiritual growth, it helps users create, track, and complete different types of goals while earning points and celebrating progress.

## 🌟 Features
- ✅ **Simple Goals** – One-time goals that can be completed and give points.
- 🔁 **Eternal Goals** – Repetitive goals that never complete, but reward points every time.
- 📋 **Checklist Goals** – Multi-step goals that provide incremental progress and a bonus when fully completed.
- 📈 Score tracking for all goals.
- ✍️ Save and load goals and progress to/from a text file.
- 🎮 Gamification-ready design to keep users engaged.
- 🔹 **New: Leveling System** – Based on the user's total points, they advance through levels such as "Novice", "Achiever", and "Champion".

## 🧱 Design Principles Used
- **Abstraction**: Each goal type is its own class with relevant attributes and behavior.
- **Encapsulation**: Member variables are private or protected, and access is through public methods.
- **Inheritance**: All goal types inherit from the abstract `Goal` base class.
- **Polymorphism**: Methods like `RecordEvent()` and `GetDetailsString()` are overridden in each derived class.

## 📂 File Structure
```
├── Program.cs             # Main menu and entry point
├── Goal.cs                # Abstract base class
├── SimpleGoal.cs          # One-time goal
├── EternalGoal.cs         # Infinite recurring goal
├── ChecklistGoal.cs       # Goal with multiple steps and bonus
├── GoalManager.cs         # Manages creation, tracking, saving, and loading
```

## 🛠 How to Run
1. Open the solution in **Visual Studio Code** or any C# compatible IDE.
2. Make sure each class is in its own `.cs` file as listed above.
3. Build the project to ensure there are no errors.
4. Run the program and follow the menu to create and track goals.

## 📀 Save Format Example
```
1000
SimpleGoal|Run a Marathon|Complete 42k run|1000|True
EternalGoal|Read Scriptures|Daily reading|100
ChecklistGoal|Attend Temple|Weekly visit|50|500|10|3
```

## 🚀 Exceeding Requirements
This project is designed to be extended easily.:
- 🎮 **Leveling System** (e.g. Level 1–10 depending on points).

> 📝 *This implementation exceeds requirements by including a Leveling System based on the user's total score. See `GetLevel()` method in `GoalManager.cs`.*

## 👨‍💼 Author
Project developed for BYU Pathway — Week 6 Programming Assignment.

