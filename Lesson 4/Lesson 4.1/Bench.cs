using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_4._1
{
    public class Bench
    {
        private string[] strArray;
        private HashSet<string> hashSet;
        private GenerateStr generateString;
        private Random rand;
        private int numberOfItems = 10000;

        private string RandomString { get; set; }
        private int Index { get; set; }

        public Bench()
        {
            hashSet = new HashSet<string>();
            strArray = new string[10001];

            rand = new Random(345);
            generateString = new GenerateStr();

            AddValues();
        }

        public void AddValues()
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                var str = generateString.GenerateStrings(rand, 10);
                strArray[i] = str;
                hashSet.Add(str);
            }
        }

        [Benchmark]
        public void TestOfStringArray()
        {
            Index = rand.Next(numberOfItems);
            RandomString = strArray[Index];
            for (int i = 0; i < numberOfItems; i++)
            {
                if (strArray[i] == RandomString)
                {
                    return;
                }
            }
        }

        [Benchmark]
        public void TestOfHashSet()
        {
            Index = rand.Next(numberOfItems);
            RandomString = strArray[Index];
            for (int i = 0; i < numberOfItems; i++)
            {
                if (hashSet.Contains(RandomString))
                {
                    return;
                }
            }
        }
    }
}
