using System;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 2, 6, 3, 5 };
            Console.WriteLine(BinarySearch(array, 2)); 


        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int minValue = 0;
            int maxValue = inputArray.Length - 1;
            while (minValue <= maxValue)
            {
                int mid = (minValue + maxValue) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    maxValue = mid - 1;
                }
                else
                {
                    minValue = mid + 1;
                }
            }
            return -1;
        }
    }
}
