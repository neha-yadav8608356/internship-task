using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TaskManagerApp
{
    // Task 4: Interfaces implement karna
    public interface INotifiable { void SendNotification(); }
    public interface IPrioritizable { string Priority { get; set; } }

    // Task 1: Base Task class properties ke saath
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public string TaskType { get; set; }

        public virtual void DisplayTask()
        {
            string status = IsComplete ? "✅ Done" : "⏳ Pending";
            Console.WriteLine($"[{Id}] {Title} ({TaskType}) - Due: {DueDate.ToShortDateString()} - {status}");
        }
    }

    // Task 3: Inheritance for different task types
    public class PersonalTask : TaskItem, INotifiable
    {
        public PersonalTask() => TaskType = "Personal";
        public void SendNotification() => Console.WriteLine($"🔔 Reminder: Personal task '{Title}' is due!");
    }

    public class WorkTask : TaskItem, IPrioritizable
    {
        public string Priority { get; set; } = "Normal";
        public WorkTask() => TaskType = "Work";
        public override void DisplayTask()
        {
            base.DisplayTask();
            Console.WriteLine($"   Priority: {Priority}");
        }
    }

    class Program
    {
        // Task 6: File Persistence (JSON file path)
        static string filePath = "tasks.json";
        static List<TaskItem> tasks = new List<TaskItem>();

        static void Main(string[] args)
        {
            LoadTasks(); // Shuruat mein file se data load karein

            while (true)
            {
                Console.WriteLine("\n--- Console Task Manager ---");
                Console.WriteLine("1. Add Task  2. View Tasks  3. Mark Complete  4. Delete Task  5. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1") AddNewTask();
                else if (choice == "2") ViewTasks();
                else if (choice == "3") UpdateTaskStatus();
                else if (choice == "4") DeleteTask();
                else if (choice == "5") { SaveTasks(); break; }
            }
        }

        // Task 2: CRUD - Create Operation
        static void AddNewTask()
        {
            Console.Write("Title: "); string title = Console.ReadLine();
            Console.Write("Type (1 for Personal, 2 for Work): ");
            string type = Console.ReadLine();

            TaskItem newTask = (type == "2") ? new WorkTask() : new PersonalTask();
            newTask.Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
            newTask.Title = title;
            newTask.DueDate = DateTime.Now.AddDays(1);
            
            tasks.Add(newTask);
            Console.WriteLine("✅ Task added successfully!");
        }

        // Task 2: CRUD - Read/Filter Operation
        static void ViewTasks()
        {
            Console.WriteLine("\n--- Your Tasks (Sorted by Date) ---");
            foreach (var task in tasks.OrderBy(t => t.DueDate)) // Sorting feature
            {
                task.DisplayTask();
            }
        }

        // Task 2: CRUD - Update Operation
        static void UpdateTaskStatus()
        {
            Console.Write("Enter Task ID to mark complete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var task = tasks.FirstOrDefault(t => t.Id == id);
                if (task != null) { task.IsComplete = true; Console.WriteLine("✅ Marked as complete!"); }
            }
        }

        // Task 2: CRUD - Delete Operation
        static void DeleteTask()
        {
            Console.Write("Enter Task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                tasks.RemoveAll(t => t.Id == id);
                Console.WriteLine("🗑️ Task deleted!");
            }
        }

        // Task 6: JSON Save/Load
        static void SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, json);
            Console.WriteLine("💾 Data saved to file!");
        }

        static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }
    }
}
