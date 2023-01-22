namespace WindowsProcessMonitor
{
    public class ConsoleLogs
    {
        public void InitializationMessage()
        {
            Logic.ChangeInfoMessage(true);
                if (Logic.infoMessage == true)
                {
                    Console.Write("To exit the tool, press");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" q");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Initializing...");
                    Console.WriteLine();
                }
            Logic.ChangeInfoMessage(false);
        }

        public void ArgsErrorMessage()
        {
            if (Logic.sendErrorMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect arguments!");
                Console.WriteLine("Please, exit and use the correct arguments.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Args:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ProcessName: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("the name of the process to kill");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Lifetime: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("the time (in minutes) the process can run before it's killed");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Frequency: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("the frequency (in minutes) the tool should look for the process lifetime");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Example: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("WindowsProcessMonitor.exe calc 2 1");
                Console.WriteLine();
                Console.ReadKey();
            }
        }

        public void InvalidArgMessage(string arg)
        {
            if (Logic.sendErrorMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The argument {arg} is not convertible to minutes");
                Console.WriteLine($"Please, exit and use a correct value for the {arg}");
                Console.ReadKey();
            }
        }

        public void NoProcessFoundMessage(int frequency)
        {
            if (Logic.sendErrorMessage == true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"No process was found! The tool will scan again in {frequency} minute(s)");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ProcessFoundMessage(TimeSpan time, string name, int frequency)
        {
            if (Logic.sendErrorMessage == true)
            {
                Console.WriteLine($"The process {name} was found but it only run for {time.TotalSeconds} seconds");
                Console.WriteLine($"The tool will scan again in {frequency} minute(s)");
            }
        }
    }
}
