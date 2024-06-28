using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScan
{
    internal static class TaskHelper
    {
        public static void PrintTasksByActionPathKeyword(string keyword = "*")
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"[All Scheduled Tasks With Application Path Containing: {keyword}]");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            using (TaskService ts = new TaskService())
            {
                foreach (var task in ts.AllTasks)
                {
                    try
                    {
                        foreach (var action in task.Definition.Actions.OfType<ExecAction>())
                        {
                            if (action.Path.Contains(keyword, StringComparison.OrdinalIgnoreCase) || keyword == "*")
                            {
                                Console.WriteLine($"Task Name: {task.Name}");
                                Console.WriteLine($"   Task Scheduler Folder: [{task.Folder}]");
                                Console.WriteLine($"   App: {action.Path}");
                                Console.WriteLine($"   Args: {action.Arguments}");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Checking Task: {task.Name} [Error: {ex.Message}]");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            /*
            string outpath = Path.GetDirectoryName(Environment.ProcessPath) ?? string.Empty;
            if (!string.IsNullOrEmpty(outpath))
            {
                File.WriteAllText(outpath + "\\ScheduledTasks.txt", sb.ToString());
                var pi = new ProcessStartInfo(outpath + "\\ScheduledTasks.txt") { UseShellExecute = true };
                Process.Start(pi);
            }
            */
        }

        public static void PrintTasksByKeyword(string keyword = "*")
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"[All Scheduled Tasks Containing: {keyword}]");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            using (TaskService ts = new TaskService())
            {
                foreach (var task in ts.AllTasks)
                {
                    try
                    {
                        foreach (var action in task.Definition.Actions.OfType<ExecAction>())
                        {
                            string actionArgs = action.Arguments ?? string.Empty;
                            if (action.Path.Contains(keyword, StringComparison.OrdinalIgnoreCase) || actionArgs.Contains(keyword, StringComparison.OrdinalIgnoreCase) || keyword == "*")
                            {
                                Console.WriteLine($"Task Name: {task.Name}");
                                Console.WriteLine($"   Task Scheduler Folder: [{task.Folder}]");
                                Console.WriteLine($"   App: {action.Path}");
                                Console.WriteLine($"   Args: {action.Arguments}");
                                Console.WriteLine(new string('-', 50));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Checking Task: {task.Name} [Error: {ex.Message}]");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            /*
            string outpath = Path.GetDirectoryName(Environment.ProcessPath) ?? string.Empty;
            if (!string.IsNullOrEmpty(outpath))
            {
                File.WriteAllText(outpath + "\\ScheduledTasks.txt", sb.ToString());
                var pi = new ProcessStartInfo(outpath + "\\ScheduledTasks.txt") { UseShellExecute = true };
                Process.Start(pi);
            }
            */
        }





    }
}
