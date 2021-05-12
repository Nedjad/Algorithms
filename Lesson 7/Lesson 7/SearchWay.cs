using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_7
{
    class SearchWay
    {

        public int N { get; set; } //Количество строк
        public int M { get; set; } //Количество столбцов

        public SearchWay(int row, int column)
        {
            N = row;
            M = column;
        }

        /// <summary>
        /// Метод вывода доски (матрицы) на экран
        /// </summary>
        public void PrintBoard(int[,] map)
        {
            Console.WriteLine("Количество маршрутов");
            Console.WriteLine();
            for (int i = 0; i < M; i++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    var result = map[i, j];
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");
                    if (map[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("{0, 3}", result);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                Console.Write("\r\n");
            }
            for (int i = 0; i < M; i++)
            {
                Console.Write("+---");
            }
        }

        
        
    }
}
