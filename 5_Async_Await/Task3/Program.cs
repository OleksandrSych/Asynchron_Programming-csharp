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
        internal static void Main()
        {
            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

            int num = 100;
            FactorialAsync(num);
            Console.ReadLine();
        }

        private static async Task FactorialAsync(int num)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - поток {Thread.CurrentThread.Name} из пула {Thread.CurrentThread.IsThreadPoolThread} ");
            int result = await Task.Run(() =>
            {
                int factorial = 1;
                for (int i = factorial; i <= num; i++)
                    factorial *= i;
                return factorial;
            }).ConfigureAwait(false); 
            Console.WriteLine($"{num} != {result}");
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] - поток {Thread.CurrentThread.Name} из пула {Thread.CurrentThread.IsThreadPoolThread} ");
        }
    }
}
