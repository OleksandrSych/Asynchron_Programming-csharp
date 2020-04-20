using System;
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
            Parallel.For(0, myArray.Length, (i) =>
             {
                 myArray[i] = i;
             }
            );
            var result = myArray.AsParallel().Where(x => Math.Log(x, 2) == (int)Math.Log(x, 2));
            Console.WriteLine (String.Join(", ", result));
            Console.ReadLine();
        }
    }
}
