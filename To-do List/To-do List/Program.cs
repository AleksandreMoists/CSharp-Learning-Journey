// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View all tasks");
            Console.WriteLine("3. Mark a task as complete");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter the task description: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(description);
                    Console.WriteLine("Task added successfully!");
                    break;
                case "2":
                    List<TaskItem> allTasks = taskManager.GetAllTasks();

                    if (allTasks.Count == 0)
                    {
                        Console.WriteLine("No task to show.");
                    }

                    foreach (TaskItem task in allTasks) {
                        string statusMarker = task.IsDone ? "X" : " ";

                        Console.WriteLine($"[{statusMarker}] {task.Id}: {task.Description}");
                    } 
                    break;
                case "3":
                    List<TaskItem> tasks = taskManager.GetAllTasks();
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No task to show.");
                    }

                    foreach (TaskItem task in tasks)
                    {
                        string statusMarker = task.IsDone ? "X" : " ";

                        Console.WriteLine($"[{statusMarker}] {task.Id}: {task.Description}");
                    }

                    Console.WriteLine("Enter the ID of task you want to complete: ");
                    string IdString = Console.ReadLine();
                    bool isNumber = int.TryParse(IdString, out int id);

                    if(isNumber)
                    {
                        taskManager.MarkTaskAsComplete(id);
                        Console.WriteLine("Task marked as complete!");
                    } else
                    {
                        Console.WriteLine("Invalid input. Please enter a number for the ID.");
                    }

                    break;
                case "4":
                    break;

            }
            
            
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

public class TaskManager
{
    private List<TaskItem> _tasks;
    private int _nextId = 1;

    public TaskManager()
    {
        _tasks = new List<TaskItem>();
    }

    public void AddTask(string description)
    {
        TaskItem newTask = new TaskItem(_nextId, description);
        _tasks.Add(newTask);
        _nextId++;
    }

    public List<TaskItem> GetAllTasks()
    {
        return _tasks;
    }

    public void MarkTaskAsComplete(int  id)
    {
        foreach (TaskItem task in _tasks)
        {
            if(task.Id == id)
            {
                task.IsDone = true;
                return;
            }
        }
        Console.WriteLine($"Task ID: {id} not found.");
    }
}

public class TaskItem
{
    public int Id { get; private set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public TaskItem(int id, string description)
    {
        Id = id;
        Description = description;
    }
}
