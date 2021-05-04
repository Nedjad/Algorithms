using System;

namespace Lesson_7
{
    class Program
    {

        const int N = 3;
        const int M = 3;

        static void Step(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\r\n");
            }
        }

        static void Main()
        {

            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; 
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            Step(N, M, A);


        }
        

    }
}
