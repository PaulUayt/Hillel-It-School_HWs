using System;
using System.Collections.Generic;
using System.Threading;

class BarberShop
{
    // Кількість вільних місць для очікування в приймальній
    private static readonly int WaitingSeats = 3;

    // Семафор для контролю доступу до крісел для відвідувачів
    private static Semaphore waitingRoomSemaphore = new Semaphore(WaitingSeats, WaitingSeats);

    // Семафор для контролю доступу до перукаря
    private static Semaphore barberSemaphore = new Semaphore(0, 1);

    // Потік для перукаря
    private static Thread barberThread;

    // Черга для зберігання ідентифікаторів клієнтів
    private static Queue<int> customerQueue = new Queue<int>();

    // Логічна змінна для перевірки, чи є перукар вільний
    private static bool isBarberAvailable = true;

    // Лок для синхронізації доступу до черги клієнтів
    private static readonly object lockObj = new object();

    static void Main()
    {
        // Запуск потоку перукаря
        barberThread = new Thread(Barber);
        barberThread.Start();

        // Створення кількох клієнтів
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(1000); // Імітація часу між клієнтами
            Thread customerThread = new Thread(() => Customer(i));
            customerThread.Start();
        }

        // Чекати на завершення роботи перукаря
        barberThread.Join();
    }

    // Метод для перукаря
    static void Barber()
    {
        while (true)
        {
            // Перукар засинає, чекаючи на клієнта
            Console.WriteLine("Перукар спить...");
            barberSemaphore.WaitOne(); // Очікує на сигнал від клієнта

            // Перевірка, чи є клієнт у черзі
            if (customerQueue.Count > 0)
            {
                // Отримуємо ідентифікатор клієнта з черги
                int customerId = customerQueue.Dequeue();
                Console.WriteLine($"Перукар прокинувся і починає стрижку клієнта {customerId}!");
                isBarberAvailable = false;  // Перукар не вільний
                Thread.Sleep(2000); // Час на стрижку
                Console.WriteLine($"Перукар закінчив стрижку клієнта {customerId}!");
                isBarberAvailable = true; // Перукар знову вільний
            }

            // Після завершення стрижки перевіряємо, чи є черга клієнтів
            if (customerQueue.Count > 0)
            {
                // Прокидаємо наступного клієнта
                barberSemaphore.Release();
            }
            else
            {
                // Якщо немає клієнтів у черзі, перукар спить
                Console.WriteLine("Перукар знову засинає...");
            }
        }
    }

    // Метод для клієнта
    static void Customer(int customerId)
    {
        Console.WriteLine($"Клієнт {customerId} прибув!");

        // Перевірка наявності вільного місця в приймальній
        Console.WriteLine($"Клієнт {customerId} перевіряє наявність вільних місць у приймальній.");

        // Спроба зайняти місце в приймальні
        if (waitingRoomSemaphore.WaitOne(0)) // 0 означає, що якщо немає вільного місця, потік не чекає
        {
            Console.WriteLine($"Клієнт {customerId} сідає у чергу очікування.");

            // Додаємо клієнта до черги тільки якщо місце є
            lock (lockObj)
            {
                if (customerQueue.Count < WaitingSeats)
                {
                    customerQueue.Enqueue(customerId);
                    Console.WriteLine($"Клієнт {customerId} доданий до черги.");
                }
                else
                {
                    // Якщо черга переповнена, клієнт залишає барбершоп і повертається пізніше
                    Console.WriteLine($"Клієнт {customerId} не зміг знайти місце і залишає барбершоп.");
                    waitingRoomSemaphore.Release(); // Вивільняємо місце в приймальні
                    return; // Клієнт йде і не чекає
                }
            }

            // Перевірка, чи є вільне крісло у перукаря
            if (isBarberAvailable)
            {
                // Клієнт сідає в крісло до перукаря
                Console.WriteLine($"Клієнт {customerId} сідає в крісло перукаря.");

                // Прокидаємо перукаря
                barberSemaphore.Release();

                // Клієнт чекає, поки перукар не завершить стрижку
                Thread.Sleep(2000); // Час стрижки

                // Після стрижки клієнт залишає крісло
                waitingRoomSemaphore.Release(); // Це дозволяє іншим клієнтам сісти в чергу
                Console.WriteLine($"Клієнт {customerId} покидає перукарню.");
            }
            else
            {
                // Якщо перукар не доступний, клієнт не може сісти в крісло і покидає перукарню
                Console.WriteLine($"Клієнт {customerId} чекає, поки перукар звільниться.");
                waitingRoomSemaphore.Release(); // Вивільняємо місце в приймальні
            }
        }
        else
        {
            // Якщо немає вільних місць у приймальній, клієнт йде
            Console.WriteLine($"Клієнт {customerId} не зміг знайти місце в приймальній і покинув перукарню.");
        }
    }
}
