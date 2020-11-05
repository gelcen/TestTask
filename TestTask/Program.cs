using System;
using System.IO;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter window value: ");
                int window = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter filename: ");
                string filename = Console.ReadLine();
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File doesn't exist");
                    return;
                }
                string[] lines = File.ReadAllLines(filename);

                var parser = new Parser(lines);
                var avg = new MovingAverage(parser.ParsedIntegers(),
                    window);

                Console.WriteLine("Result: ");
                foreach (double num in avg.Smooth())
                {
                    Console.WriteLine(num);
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
