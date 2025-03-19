namespace HW6_GarbageCollector.Action_Task1.Logger
{
    public interface ILogger : IDisposable
    {
        void WriteToLog(string message);
    }
}
