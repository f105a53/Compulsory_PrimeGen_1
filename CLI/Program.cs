using System;
using System.Collections;
using System.Linq;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(10, 1_000_000);
            Run(10, 10_000_000);
            Run(1_000_000, 2_000_000);
            Run(10_000_000, 20_000_000);
        }

        static void Run(long lower, long upper)
        {
            Console.WriteLine($"Running {lower} to {upper}");
            var start = DateTime.Now;
            var primeNumbersParallel = Compulsory_PrimeGen.Class1.GetPrimesParallel(lower, upper);
            Console.WriteLine($"\tParallel: {DateTime.Now - start}");

            start = DateTime.Now;
            var primeNumbers = Compulsory_PrimeGen.Class1.GetPrimesSequential(lower, upper).ToList();
            Console.WriteLine($"\tSequential: {DateTime.Now - start}");
        }
    }
}
