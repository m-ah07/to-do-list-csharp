using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("Welcome to the To-Do List App!");
        string command;

        do
        {
            Console.WriteLine("\nCommands: add, view, complete, delete, exit");
            Console.Write("Enter a command: ");
            command = Console.ReadLine()?.ToLower();

            switch (command)
            {
                case "add":
                    AddTask();
                    break;
                case "view":
                    ViewTasks();
                    break;
                case "complete":
                    CompleteTask();
                    break;
                case "delete":
                    DeleteTask();
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        } while (command != "exit");
    }

    static void AddTask()
    {
        Console.Write("Enter a new task: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrEmpty(task))
        {
            tasks.Add(task);
            Console.WriteLine($"Task '{task}' added!");
        }
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine("To-Do List:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void CompleteTask()
    {
        ViewTasks();
        Console.Write("Enter the task number to mark as complete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            Console.WriteLine($"Task '{tasks[taskNumber - 1]}' marked as complete!");
            tasks.RemoveAt(taskNumber - 1);
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter the task number to delete: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            Console.WriteLine($"Task '{tasks[taskNumber - 1]}' deleted!");
            tasks.RemoveAt(taskNumber - 1);
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }
    }
}
