﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.Write("Start");
           await CalculateFactorialAsync(10);
            Console.ReadLine();
        }
        private static async Task CalculateFactorialAsync(int number)
        {
            int factorial = await Task<int>.Run(() => CalculateFactorial(number));
            Console.WriteLine($"\n{number}! = {factorial}");
        }

        private static int CalculateFactorial(int number)
        {
            Thread.Sleep(500);
            if (number == 1)
                return 1;
            return number * CalculateFactorial(number - 1);
        }
    }
}
