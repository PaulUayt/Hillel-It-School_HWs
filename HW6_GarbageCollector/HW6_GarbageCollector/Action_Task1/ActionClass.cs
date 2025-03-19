using HW6_GarbageCollector.Action_Task1.Logger;

namespace HW6_GarbageCollector.Action_Task1
{
    public class ActionClass
    {
        private readonly ILogger logger;

        public string ActionName { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double ActionLength { get; set; }

        public ActionClass(string actionName, string authorName, string genre, int year, double actionLength, ILogger logger)
        {
            ActionName = actionName;
            AuthorName = authorName;
            Genre = genre;
            Year = year;
            ActionLength = actionLength;
            this.logger = logger;

            logger.WriteToLog($"Action {ActionName} created");
        }

        public void GetActionInfo()
        {
            Console.WriteLine($"Action: {ActionName}, Author: {AuthorName}, Genre: {Genre}, Year: {Year}, Length: {ActionLength}");
            logger.WriteToLog($"Action: {ActionName}, Author: {AuthorName}, Genre: {Genre}, Year: {Year}, Length: {ActionLength}");
        }

        public void StartAction()
        {
            Console.WriteLine($"Action {ActionName} started");
            logger.WriteToLog($"Action {ActionName} started");
        }

        public void StopAction()
        {
            Console.WriteLine($"Action {ActionName} stopped");
            logger.WriteToLog($"Action {ActionName} stopped");
        }

        public void PauseAction()
        {
            Console.WriteLine($"Action {ActionName} paused");
            logger.WriteToLog($"Action {ActionName} paused");
        }
    }
}
