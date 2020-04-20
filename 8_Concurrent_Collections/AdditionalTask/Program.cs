using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10_000_000];
            Parallel.For(0, myArray.Length, (i) => { myArray[i] = i; });
            var stack = new ConcurrentStack<int>();
            Parallel.ForEach<int>(myArray, (i) =>
            {
                if (Math.Log(i, 2) == (int)Math.Log(i, 2))
                    stack.Push(i);
            });
            Console.WriteLine(String.Join(", ", stack));
            Console.ReadLine();
        }
    }
}
