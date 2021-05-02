using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    class Vertex
    {
        public bool Visited { get; set; }
        public int Number { get; set; } 
        public Vertex(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
