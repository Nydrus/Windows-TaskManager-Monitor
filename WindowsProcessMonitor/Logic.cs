using System.Diagnostics;

namespace WindowsProcessMonitor
{
    public class Logic
    {
        private ConsoleLogs _logs;
        private string? _name;
        private TimeSpan _lifetime;
        private int _frequency;
        private Timer _timer;
        public static bool sendErrorMessage = false;
        public static bool infoMessage = false;

        public void Run(string[] args)
        {
            args = new string[]{"notepad","1", "1"}; // Testing purposes

            _logs = new ConsoleLogs();
            _logs.InitializationMessage();
            ArgsCast(args);
            Console.ReadKey();
        }
        public bool ChangeSendErrorMessage(bool val)
        {
            if (val == true)
            {
                sendErrorMessage= true;
                return true;
            }
            sendErrorMessage= false;
            return false;
        }
        public static bool ChangeInfoMessage(bool value)
        {
            if(value == true)
            {
                infoMessage = true;
                return true;
            }
            infoMessage = false;
            return false;
        }

        public void TimerCallBack(object? obj)
        {
            _timer.Change((int)TimeSpan.FromMinutes(_frequency).TotalMilliseconds, Timeout.Infinite);
            Process? process = Process.GetProcessesByName(_name).FirstOrDefault();

            if (process == null)
            {
                ChangeSendErrorMessage(true);
                _logs.NoProcessFoundMessage(_frequency);
                return;
            }
            
                try
                {
                    if ((DateTime.Now - process.StartTime).Ticks <= _lifetime.Ticks)
                {
                    ChangeSendErrorMessage(true);
                    _logs.ProcessFoundMessage(DateTime.Now - process.StartTime, _name, _frequency);
                    return;
                }
                }
                catch (Exception ex)
                {
                }
            
                ChangeSendErrorMessage(false);
                KillProcess(process);
            
        }

        public void ArgsCast(string[] args)
        {
            if (args == null || !args.Any() || args.Length != 3)
            {
                ChangeSendErrorMessage(true);
                _logs.ArgsErrorMessage();
            }
            else
            {
                _name = args[0];

                if (!double.TryParse(args[1], out double minutes))
                {
                    ChangeSendErrorMessage(true);
                    _logs.InvalidArgMessage("Lifetime");    
                }
                _lifetime = TimeSpan.FromMinutes(minutes);

                if (!int.TryParse(args[2], out _frequency))
                {
                    ChangeSendErrorMessage(true);
                    _logs.InvalidArgMessage("Frequency");
                }
                ChangeSendErrorMessage(false);
                _timer = new Timer(TimerCallBack, null, 1, Timeout.Infinite);
            }
        }

        public void KillProcess(Process process)
        {
            if (sendErrorMessage == false)
            {
                Console.WriteLine($"Process is running for {Math.Round((DateTime.Now - process.StartTime).TotalMinutes, 0)} minute(s). Killing it...");
                process.Kill();
                Console.WriteLine($"The process was killed successfully! The tool will continue scanning in {_frequency} minute(s).");
            }
        }
    }
}
