namespace HW6_GarbageCollector.Action_Task1.Logger
{
    class Logger : ILogger, IDisposable
    {
        private bool disposed = false;
        private StreamWriter fileWriter;

        public Logger(string filePath)
        {
            fileWriter = new StreamWriter(filePath, append: true);
        }

        public void WriteToLog(string message)
        {
            if (fileWriter != null)
            {
                fileWriter.WriteLine($"{DateTime.Now} - {message}");
                fileWriter.Flush();
            }
        }

        ~Logger()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) return;
            if (disposing)
            {
                fileWriter?.Dispose();
            }
            disposed = true;
            fileWriter = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
