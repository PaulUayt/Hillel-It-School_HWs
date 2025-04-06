using System;
using System.Collections.Generic;
using System.Threading;

class BarberShop
{
    private static readonly int WaitingSeats = 3;
    private static Semaphore waitingRoomSemaphore = new Semaphore(WaitingSeats, WaitingSeats);
    private static Semaphore barberSemaphore = new Semaphore(0, 1);
    private static Thread barberThread;

    static void Main()
    {
        barberThread = new Thread(Barber);
        barberThread.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(new Random().Next(1000, 3000)); 
            Thread customerThread = new Thread(() => Customer(i));
            customerThread.Start();
        }

        barberThread.Join();
    }

    static void Barber()
    {
        while (true)
        {
            Console.WriteLine("Перукар спить...");
            barberSemaphore.WaitOne(); 

            string customerId = Thread.CurrentThread.Name;
            Console.WriteLine($"Перукар прокинувся і починає стрижку клієнта {customerId}!");
            Thread.Sleep(2000);
            Console.WriteLine($"Перукар закінчив стрижку клієнта {customerId}!");
        }
    }

    static void Customer(int customerId)
    {
        Console.WriteLine($"Клієнт {customerId} прибув!");

        Console.WriteLine($"Клієнт {customerId} перевіряє наявність вільних місць у приймальні.");

        if (waitingRoomSemaphore.WaitOne(0)) 
        {
            Console.WriteLine($"Клієнт {customerId} сідає у чергу очікування.");

            Thread.Sleep(1000); 

            Console.WriteLine($"Клієнт {customerId} сідає в крісло перукаря.");

            barberSemaphore.Release(); 

            Thread.Sleep(2000);

            waitingRoomSemaphore.Release();
            Console.WriteLine($"Клієнт {customerId} покидає перукарню.");
        }
        else
        {
            Console.WriteLine($"Клієнт {customerId} не зміг знайти місце в приймальні і покинув перукарню.");
        }
    }
}
