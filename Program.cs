using System.Collections.Concurrent;
using System.Text;

namespace HW_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            int n = 100;
            ConcurrentQueue<int> primes = FindPrime(n);

            Console.WriteLine($"Прості числа від 0 до {n} : ");
            foreach (int p in primes)
            {
                Console.Write(p + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public static ConcurrentQueue<int> FindPrime(int N)
        {
            ConcurrentQueue<int> primeNums = new ConcurrentQueue<int>();
            Parallel.For(2, N + 1, (i, loopState) =>
            {
                if (IsPrime(i))
                {
                    primeNums.Enqueue(i);
                }
            });
            return primeNums;
        }
        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}