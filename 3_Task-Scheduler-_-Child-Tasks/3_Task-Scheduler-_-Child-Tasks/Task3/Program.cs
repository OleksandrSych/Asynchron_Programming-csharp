using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        { 
            DelayTaskScheduler scheduler = new DelayTaskScheduler();
            Task task = new Task(() =>
            { 
                Console.WriteLine($"\nВыполнена задача {Task.CurrentId} в потоке из пула {Thread.CurrentThread.IsThreadPoolThread} ");
            });
            task.Start(scheduler);
            while (task.IsCompleted == false)
            {
                Console.Write($"* ");
                Thread.Sleep(100);
            }
            Console.ReadLine();
        }
    }
}
