using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<double> task = new Task<double>(() => FindLastFibonacciNumber(40), TaskCreationOptions.LongRunning);
            task.Start();
            while (!task.IsCompleted)
            {
                Console.Write('$');
                Thread.Sleep(200);
            }
            Console.Write($"\n Последнее число из последовательности Фибоначчи: {task.Result}");
            Console.ReadLine();
        }
        private static double FindLastFibonacciNumber(int number)
        {
            Func<int, double> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            return fib.Invoke(number);

        }
    }
}
