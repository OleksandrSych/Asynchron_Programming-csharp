using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[1000];
            Parallel.For(0, myArray.Length, (i) => { myArray[i] = i; });
            var result = myArray.AsParallel().AsOrdered().Where(x => x % 2 == 0);
            Console.WriteLine(String.Join(", ", result));
            Console.ReadLine();
        }
    }
}
