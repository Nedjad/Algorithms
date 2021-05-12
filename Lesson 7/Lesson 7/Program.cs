using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] matrix = new int[15, 15];
            SearchWay sw = new SearchWay(15,15);
            sw.PrintBoard(matrix);
            

        }

        
    }
}


       
           
