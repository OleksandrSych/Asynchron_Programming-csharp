using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        private static async Task Main()
        {
            string txt = await GetTextAsync();
            int countItvdn = await GetCount_itvdnAsync(txt);
            Console.WriteLine("itvdn - " + countItvdn);
            Console.ReadLine();
        }
        static async Task<string> GetTextAsync()
        {
            string url = "https://itvdn.com";
            return await (new HttpClient()).GetStringAsync(url);
        }
        static async Task<int> GetCount_itvdnAsync(string txt)
        {
            return await Task.Run(() =>
            {
                return (txt.Length - txt.ToLower().Replace("itvdn", "").Length) / ("itvdn").Length; ;
            });
        }

    }
}
