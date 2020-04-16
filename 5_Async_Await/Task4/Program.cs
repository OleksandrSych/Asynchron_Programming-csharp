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
            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

            Console.WriteLine("Start Main");
            ExeptionVoidAsync();
            Console.WriteLine("End Main");
            Console.ReadLine();
        }

        static async void ExeptionVoidAsync()
        {
           await Task.Run(() => { throw new Exception("Void Async Exception"); }); 
        }
    }
}
