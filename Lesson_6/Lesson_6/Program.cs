using System;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            //Создание 8 вершин
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);
            var v8 = new Vertex(8);

            //Добавляем вершины в граф
            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);
            graph.AddVertex(v8);

            //Добавляем ребра в между вершинами в граф
            graph.AddEdge(v1, v2);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v4, v5);
            graph.AddEdge(v1, v6);
            graph.AddEdge(v6, v7);
            graph.AddEdge(v6, v8);

            //Матрица смежностей
            graph.PrintMatrix(graph);
            Console.ReadKey();
            Console.Clear();

            //Список смежностей
            Console.WriteLine();
            Console.WriteLine("Cписок смежностей");
            Console.WriteLine();
            graph.PrintVertex(v1);
            graph.PrintVertex(v2);
            graph.PrintVertex(v3);
            graph.PrintVertex(v4);
            graph.PrintVertex(v5);
            graph.PrintVertex(v6);
            graph.PrintVertex(v7);
            graph.PrintVertex(v8);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
