using HW6_GarbageCollector;

public class Program
{
    static void Main(string[] args)
    {
        // ActionClass testing


        
        using (ActionClass action = new ActionClass("The Matrix", "Wachowski", "Drama", 1999, 2.16))
        {
            action.GetActionInfo();
            Console.WriteLine();
            action.StartAction();
            action.PauseAction();
        }
        Console.WriteLine();

        using (ActionClass action2 = new ActionClass("Natalka Poltavka", "M.Kocubinskyi", "Melodrama", 2003, 2.18))
        {
            action2.GetActionInfo();
            Console.WriteLine();
            action2.StartAction();
            action2.PauseAction();
        }
    }
}
