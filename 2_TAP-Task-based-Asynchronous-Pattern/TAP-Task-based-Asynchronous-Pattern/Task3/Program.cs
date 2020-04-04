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
            Task<int[]> task = new Task<int[]>(() => SortArray(true, 2, 3, 6, 3, 9, 3, 0));
            task.Start();
            task.Wait();
            Console.WriteLine("true:  " + String.Join(", ", task.Result));
            task = new Task<int[]>(() => SortArray(false, 2, 3, 6, 3, 9, 3, 0));
            task.Start();
            task.Wait();
            Console.WriteLine("false: " + String.Join(", ", task.Result));
            Console.ReadLine();
        }
        private static int[] SortArray(bool isAscending, params int[] array)
        {
            if (isAscending)
                return array.OrderBy(x => x).ToArray();
            return array.OrderByDescending(x => x).ToArray();
        }
    }
}
