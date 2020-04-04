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
            ThreadPoolWorker threadPoolWorker1 = new ThreadPoolWorker(new Action<object>(WriteChar));
            ThreadPoolWorker threadPoolWorker2 = new ThreadPoolWorker(new Action<object>(WriteChar));
            threadPoolWorker1.Start('*'); 
            threadPoolWorker2.Start('!');

            threadPoolWorker1.Wait();
            threadPoolWorker2.Wait();
             
            Console.ReadLine();

        }
        static void WriteChar(object symbol)
        {
            for (int i = 0; i < 160; i++)
            {
                Console.Write((char)symbol);
                Thread.Sleep(100);
            }
        }
    }
}
