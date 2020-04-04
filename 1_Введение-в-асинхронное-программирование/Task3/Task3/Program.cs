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
            ThreadPoolWorker<int> threadPoolWorker = new ThreadPoolWorker<int>(Calculate);
            threadPoolWorker.Start(150);
            while (threadPoolWorker.IsCompleted == false)
            {
                Console.Write("*");
                Thread.Sleep(35);
            }

            Console.WriteLine();
            Console.WriteLine($"Результат асинхронной операции = {threadPoolWorker.Result:N}");
            Console.ReadLine();
        }
        static int Calculate(object sleepTime)
        {
            int sTime = (int)sleepTime;
            for (int i = 0; i < 10; i++)
            {
                sTime += i;
                Thread.Sleep(sTime);
            }
            return sTime;
        }
    }
}
