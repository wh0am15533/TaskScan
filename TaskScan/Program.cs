

namespace TaskScan
{
    internal class Program
    {
        #region[Declarations]

        public static string localMachineName = System.Environment.MachineName;





        #endregion
        
        
        static void Main(string[] args)
        {
            if (args.Length == 2 && args[0].ToLower().Trim() == "-search" && !string.IsNullOrEmpty(args[1].ToLower().Trim()))
            {
                TaskHelper.PrintTasksByKeyword(args[1].ToLower().Trim());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TaskScan v1.0");
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("\r\nUsage: taskscan -search searchstring");
                Console.WriteLine("Example: taskscan -search powershell.exe");
                Console.WriteLine("Example: taskscan -search hidden");
            }

            #region[App Exit Prompt]

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n" + new string('-', 50));
            Console.WriteLine("[Press any to to exit.]");
            Console.ReadLine();

            #endregion
        }


    }

}
