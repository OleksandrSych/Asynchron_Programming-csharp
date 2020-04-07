using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Main в потоке {Thread.CurrentThread.ManagedThreadId} ");
            StackTaskScheduler scheduler = new StackTaskScheduler();

            Task[] tasks = new Task[40];

            for (int i = 0; i < 40; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine($"Выполнена задача {Task.CurrentId} в потоке {Thread.CurrentThread.ManagedThreadId} ");
                });
                tasks[i].Start(scheduler);
            }

            Task.WaitAll(tasks);
            Console.ReadLine();
        }
    }
}
