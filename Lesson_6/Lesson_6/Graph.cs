using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_6
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();
        
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgesCount => Edges.Count;

        
        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        
        public List<Vertex> DFSsearch(Vertex start, int searchValue)
        {
            Console.WriteLine("DFSsearch");
            Console.WriteLine();
            
            var bufer = new Stack<Vertex>();
            
            List<Vertex> returnArray = new List<Vertex>();
            
            bufer.Push(start);
            
            if (bufer == null)
            {
                return null;
            }

            while (bufer.Count != 0)
            {
                var element = bufer.Pop();

                if (element.Number == searchValue)
                {
                    element.Visited = true;
                    Console.WriteLine();
                    Console.WriteLine($"Искомый элемент: [{element.Number}] Посещен: [{element.Visited}] ");
                    break;
                }
                

                returnArray.Add(element);
                element.Visited = true;
                Console.WriteLine($"--> [{element.Number}] Посещен: [{element.Visited}]");
                
                for (int i = 0; i < Edges.Count; i++)
                {
                    if (element == Edges[i].From)
                    {
                        if (Edges[i].To.Visited != true)
                        {
                            bufer.Push(Edges[i].To);
                        }
                    }
                }
            }
            return returnArray;
        }

        
        public List<Vertex> BFSsearch(Vertex start, int searchValue)
        {
            Console.WriteLine("BFSsearch");
            Console.WriteLine();
            
            var bufer = new Queue<Vertex>();
            
            var returnArray = new List<Vertex>();
           
            bufer.Enqueue(start);
            
            if (bufer == null)
            {
                return null;
            }
            
            while (bufer.Count != 0)
            {
                
                var element = bufer.Dequeue();
                
                if (element.Number == searchValue)
                {
                    element.Visited = true;
                    Console.WriteLine();
                    Console.WriteLine($"Искомый элемент: [{element.Number}] Посещен: [{element.Visited}] ");
                    break;
                }
                else
                {
                    
                    foreach (var edgesNear in Edges)
                    {
                        if (element == edgesNear.From)
                        {
                            bufer.Enqueue(edgesNear.To);
                        }
                    }
                    
                    if (element.Visited != true)
                    {
                        returnArray.Add(element);
                        element.Visited = true;
                        Console.WriteLine($"--> [{element.Number}] [{element.Visited}]");
                    }
                }
            }
            return returnArray;
        }

        
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        
        public void PrintVertex(Vertex vertex)
        {
            Console.Write($"[{vertex.Number}] -> ");
            foreach (var v in GetVertex(vertex))
            {
                Console.Write($"[{v}];");
            }
            Console.WriteLine();
        }
        private HashSet<Vertex> GetVertex(Vertex vertex)
        {
            var result = new HashSet<Vertex>();

            foreach (var edge in Edges)
            {
                if (vertex == edge.From)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }

        
        public void PrintMatrix(Graph graph)
        {
            Console.WriteLine("Матрица смежностей");
            Console.WriteLine();
            var matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($"{i + 1} |");
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(string.Format("{0, 3}", $"{matrix[i, j]}"));
                }
                Console.WriteLine();
            }
        }

        private int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Number - 1;
                var column = edge.To.Number - 1;

                matrix[row, column] = edge.Weight;
            }
            return matrix;
        }
    }
}
