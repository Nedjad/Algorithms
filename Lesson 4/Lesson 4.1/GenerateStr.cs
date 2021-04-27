using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4._1
{
    class GenerateStr
    {
        private char GenerateChars(Random rand)
        {
            return (char)(rand.Next('A', 'Z' + 1));
        }

        public string GenerateStrings(Random rand, int len)
        {
            char[] letters = new char[len];

            for (int i = 0; i < len; i++)
            {
                letters[i] = GenerateChars(rand);
            }
            return new string(letters);
        }
    }
}
