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
            Task task = new Task(WriteChar, '!');
            task.Start();
            while(!task.IsCompleted)
            {
                Console.Write('$');
                Thread.Sleep(200);
            }
            Console.Write("\n Метод Main закончил свою работу");
            Console.ReadLine();
        }

        private static void WriteChar(object symbol)
        {
            for(int i = 0; i<160;i++)
            {
                Console.Write((char)symbol);
                Thread.Sleep(500);
            }
        }
    }
}
