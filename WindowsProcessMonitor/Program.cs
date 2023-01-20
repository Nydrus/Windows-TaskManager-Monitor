namespace WindowsProcessMonitor
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new();
            logic.Run(args);
        }
    }
}