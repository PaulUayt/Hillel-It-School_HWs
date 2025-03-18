namespace HW6_GarbageCollector
{
    public class ActionClass : IDisposable
    {
        private bool disposed = false;
        private const string FILE = "D:\\Hillel_C#_HWs\\HW6_GarbageCollector\\HW6_GarbageCollector\\Actions_log.txt";
        private StreamWriter fileWriter;

        public string ActionName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double ActionLength { get; set; }

        public ActionClass(string actionName, string authorName, string genre, int year, double actionLength)
        {
            ActionName = actionName;
            AuthorName = authorName;
            Genre = genre;
            Year = year;
            ActionLength = actionLength;

            fileWriter = new StreamWriter(FILE, append: true);
            WriteToLog($"Action {ActionName} created");
        }

        ~ActionClass()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                StopAction();
                fileWriter.Close();
                fileWriter.Dispose();
            }
            disposed = true;
        }

        public void WriteToLog(string message)
        {
            if(fileWriter != null)
            {
                fileWriter.WriteLine($"{DateTime.Now} - {message}");
                fileWriter.Flush();
            }
        }

        public void GetActionInfo()
        {
            Console.WriteLine($"Action: {ActionName}, Author: {AuthorName}, Genre: {Genre}, Year: {Year}, Length: {ActionLength}");
            WriteToLog($"Action: {ActionName}, Author: {AuthorName}, Genre: {Genre}, Year: {Year}, Length: {ActionLength}");
        }

        public void StartAction()
        {
            Console.WriteLine($"Action {ActionName} started");
            WriteToLog($"Action {ActionName} started");
        }

        public void StopAction()
        {
            Console.WriteLine($"Action {ActionName} stopped");
            WriteToLog($"Action {ActionName} stopped");
        }

        public void PauseAction()
        {
            Console.WriteLine($"Action {ActionName} paused");
            WriteToLog($"Action {ActionName} paused");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
