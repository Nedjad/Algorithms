using System;

namespace Natural_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            Console.WriteLine("Введите число:");
            number = int.Parse(Console.ReadLine());
            NaturalNumb(number);

        }

        public static int NaturalNumb(int number)
        {
            int d = 0;
            int i = 2;

            while(i < number)
            {
                if (number % i == 0)
                {
                    d++;
                    i++;     
                }                      
                else
                    i++;               
            }

            if (d == 0)
                Console.WriteLine("Число простое.");
            else
                Console.WriteLine("Число не простое.");

            return number;
        }
    }
}
