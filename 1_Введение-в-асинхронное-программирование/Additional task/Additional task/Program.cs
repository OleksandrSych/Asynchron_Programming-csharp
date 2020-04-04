using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Additional_task
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(WriteChar), '*');
            ThreadPool.QueueUserWorkItem(new WaitCallback(WriteChar), '!');
            Console.ReadLine();
        }

        static void WriteChar(object symbol)
        {
            for(int i=0; i<160; i++)
            {                
                Console.Write((char)symbol);
                Thread.Sleep(100);
            }
        }
    }

}
