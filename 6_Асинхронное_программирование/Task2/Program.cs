using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите Ваш текст:");
            string txt = Console.ReadLine();
            WriteToFileAsync(txt);
            Console.WriteLine("Текст записан в файл test.txt");
            Console.ReadLine();
        }

        static async void WriteToFileAsync(string txt)
        {
            using (FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite, 4096, FileOptions.Asynchronous))
            {  
                byte[] bytes = Encoding.UTF8.GetBytes(txt);
                await fs.WriteAsync(bytes, 0, bytes.Length); 
            }

        }
    }
}
