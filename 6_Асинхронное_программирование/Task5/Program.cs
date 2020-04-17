using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static async Task Main()
        {
            Console.Write("Your nymber:");
            int.TryParse(Console.ReadLine(), out int num);
            if (num > 0)
            {
                int sequenceSum = await SequenceSumAsync(num);
                Console.WriteLine("Sequence Sum: " + sequenceSum);
            }
            Console.ReadLine();
        }

        static Task<int> SequenceSumAsync(int num)
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            Task.Run(() =>
            {
                try
                {
                    var result = SequenceSum(num);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return tcs.Task;
        }
        static int SequenceSum(int num)
        {
            int result = 0;
            for (int i = 0; i <= num; i++)
                result += i;
            return result;
        }
    }
}
