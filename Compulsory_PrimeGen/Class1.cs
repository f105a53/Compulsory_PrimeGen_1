using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compulsory_PrimeGen
{
    public static class Class1
    {
        private static IEnumerable<long> GetPrimes(long first, long last)
        {
            for (long noToCheck = first; noToCheck <= last; noToCheck++)
            {
                long i, flag = 0;

                var m = noToCheck / 2;
                for (i = 2; i <= m; i++)
                {
                    if (noToCheck % i == 0)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    yield return noToCheck;
                }
            }
        }

        public static List<long> GetPrimesSequential(long first, long last) => GetPrimes(first,last).ToList();

        public static List<long> GetPrimesParallel(long first, long last)
        {
            var result = new ConcurrentBag<List<long>>();
            Parallel.ForEach(Partitioner.Create(first, last), range =>
            {
                result.Add(GetPrimes(range.Item1, range.Item2).ToList());
            });
            return result.OrderBy(l => l.FirstOrDefault()).SelectMany(l=>l).ToList();
        }
    }
}
