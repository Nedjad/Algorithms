using System;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Введите конец диапазона от 1 до : ");
            var n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", Fib(i));
            }
            Console.ReadKey();

            FibonacciCycle();
        }

        // Решение с рекурсией
        static int Fib(int n)
        {
            if (n <= 2)
                return 1;
            else
                return Fib(n - 1) + Fib(n - 2);
        }

        // Решение с циклом
        public static int FibonacciCycle()
        {
            Console.Write("Введите конец диапазона от 1 до : ");
            int end = int.Parse(Console.ReadLine());
            int j = 1;
            for (int i = 1; i <= end; i += j)
            {
                Console.Write("{0} ", i);
                j = i - j;
            }
            Console.ReadKey();
            return 0;
        }
    }
}
