using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        private static async Task Main()
        {
            Console.Write("Введите текст: ");
            string inputText = Console.ReadLine();
            var task = ParseAsync(inputText);
            Console.Write("Введите свое имя: ");
            string name = Console.ReadLine();
            FileStream fileStream = new FileStream("resultText.txt", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            var parseResult = await task;
            streamWriter.WriteLine($"{name} нашел {parseResult.Count} уникальных слов. Перечисление слов: ");
            streamWriter.WriteLine(string.Join(", ", parseResult) + (parseResult.Count() > 0 ? "." : string.Empty));
            streamWriter.Close();
            fileStream.Close();
            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        static async Task<IList<string>> ParseAsync(string inputData)
        {
            return await Task<IList<string>>.Run(() =>
            {
                string[] words = inputData.Split(' ', ',', '.');
                List<string> listUniqueWords = words.Distinct().ToList();
                return listUniqueWords;
            });
        }
    }
}
